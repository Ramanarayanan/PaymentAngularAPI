using System.Linq;
using Microsoft.Extensions.Options;
using PaymentWeb.business;
using BillPaymentBusness.Encryption;
using BillPaymentBusness.Validation;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using BillPaymentDataAccess.Repositary;
using BillPaymentDataAccess.UnitOfWork;
using DataAcess.Models;

namespace BillPaymentBusness.Services
{
    /// <summary>
    /// This class represents the payment service
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private const string InsufficientFunds = "Insufficient Funds";
        private const string BankErrorMessage = "The username or password is invalid";
        private const string CardErrorMessage = "The card details are invalid";

        /// <summary>
        /// The Unit of work
        /// </summary>
        private IUnitOfWork unitOfWork;
        /// <summary>
        /// The bank Repositary
        /// </summary>
        private IRepository<NetBanking> bankRepository;

        /// <summary>
        /// The cardRepositary
        /// </summary>
        private IRepository<CardPayment> cardPaymentRepository;

        /// <summary>
        /// The appsettings
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// The payment service constructer
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork</param>
        /// <param name="appSettings">The appSettings</param>
        public PaymentService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.bankRepository = unitOfWork.NetBankingRepositary;
            this.cardPaymentRepository = unitOfWork.CardPaymentRepository;
            this.unitOfWork = unitOfWork;
            this._appSettings = appSettings.Value;
        }

        /// <summary>
        /// This method resprsents Make card payment
        /// </summary>
        /// <param name="bankModel">The bankModel</param>
        /// <returns></returns>
        public PaymentStatus MakeBankPayment(BankModel bankModel)
        {
            //Validate bankmodel
            BankValidation.Validate(bankModel);       
             //Encrypt the user name
            var encryptedUserName = AesOperation.EncryptString(this._appSettings.Key, bankModel.UserName);

            //Encrypt the password
            var encryptedpassWord = AesOperation.EncryptString(this._appSettings.Key, bankModel.Password);

            var netBankList =this.bankRepository.Query();
            var netBankModel = (from netBank in netBankList
                                where netBank.Password == encryptedpassWord && netBank.UserName == encryptedUserName
                                select netBank).FirstOrDefault();
            return CompleteBankPayment(netBankModel, bankModel);
        }

        /// <summary>
        /// The Complete Payment 
        /// </summary>
        /// <param name="netBankModel">The netBankModel</param>
        /// <param name="bankModel">The bankModel</param>
        /// <returns></returns>
        private PaymentStatus CompleteBankPayment(NetBanking netBankModel, BankModel bankModel)
        {
            PaymentStatus paymentStatus = new PaymentStatus();
            //The bank details are not matched
            if (netBankModel != null)
            {    
                if (netBankModel.Amount > bankModel.Amount)
                {
                    netBankModel.Amount = (netBankModel.Amount - bankModel.Amount);
                    this.bankRepository.Update(netBankModel);
                    unitOfWork.Save();
                    paymentStatus.Status = true;
                }
                else
                {
                    paymentStatus.Error = InsufficientFunds;
                }
            }
            else
            {
                paymentStatus.Error = BankErrorMessage;

            }

            return paymentStatus;
        }
             
        /// <summary>
        /// This method represents Make card payment 
        /// </summary>
        /// <param name="cardPaymentModel"></param>
        /// <returns></returns>
          public PaymentStatus MakeCardPayment(CardPaymentModel cardPaymentModel)
        {
            PaymentValidation.ValidateCardPayment(cardPaymentModel);
            var unEncryptedCardNumber = cardPaymentModel.CardNumber;
            var suffixCardNumber = unEncryptedCardNumber.Substring(unEncryptedCardNumber.Length - 4, 4);
            var preFixCard = unEncryptedCardNumber.Substring(0, unEncryptedCardNumber.Length - 4);
            var encryptedCardNumber = AesOperation.EncryptString(this._appSettings.Key, suffixCardNumber);
            var encryptedCvvNumber = AesOperation.EncryptString(this._appSettings.Key, cardPaymentModel.Cvvnumber);

            string errorMessage;
            
            var cardDetailsList = this.cardPaymentRepository.Query();
            var cardPayment = (from cardDetail in cardDetailsList
                               where cardDetail.CardNumber == (encryptedCardNumber+ suffixCardNumber) && cardDetail.Cvvnumber == encryptedCvvNumber && cardDetail.ExpiryDate == cardPaymentModel.ExpiryDate
                               select cardDetail).FirstOrDefault();

            return CompleteCardPament(cardPaymentModel, cardPayment);
        }

        /// <summary>
        /// This method complete card payment 
        /// </summary>
        /// <param name="cardPaymentModel"></param>
        /// <param name="cardPayment"></param>
        /// <returns></returns>
        private PaymentStatus CompleteCardPament(CardPaymentModel cardPaymentModel,CardPayment cardPayment)
        {
            PaymentStatus paymentStatus = new PaymentStatus();
            if (cardPayment != null)
            {
                if (cardPayment.Amount > cardPaymentModel.Amount)
                {
                    cardPayment.Amount = (cardPayment.Amount - cardPaymentModel.Amount);
                    this.cardPaymentRepository.Update(cardPayment);
                    unitOfWork.Save();
                    paymentStatus.Status = true;
                }
                else
                {
                    paymentStatus.Error = InsufficientFunds;
                }

            }
            else
            {
                paymentStatus.Error = CardErrorMessage;
            }

            return paymentStatus;
        }
    }
}
