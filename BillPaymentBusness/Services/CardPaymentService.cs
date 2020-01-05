using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using PaymentWeb.business;
using BillPaymentBusness.Encryption;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using BillPaymentDataAccess.Repositary;
using BillPaymentDataAccess.UnitOfWork;
using DataAcess.Models;

namespace BillPaymentBusness.Services
{
    /// <summary>
    /// This class represents the CardPaymentService
    /// </summary>
    public class CardPaymentService : ICardPaymentService
    {
        /// <summary>
        /// The Unit of work
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The cardRepositary
        /// </summary>
        private IRepository<CardPayment> CardPaymentRepository;

        /// <summary>
        /// The app settings
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// The Cardpayment Constructer
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork</param>
        /// <param name="appSettings">The appSettings</param>
        public CardPaymentService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.CardPaymentRepository = unitOfWork.CardPaymentRepository;
            this.unitOfWork = unitOfWork;
            this._appSettings = appSettings.Value;
        }

        /// <summary>
        /// This method to add card details
        /// </summary>
        /// <param name="cardPaymentModel">The cardPaymentModel</param>
        /// <returns>returns cardPaymentModel</returns>
        public bool AddCardPaymentDetails(CardPaymentModel cardPaymentModel)
        {
            var unEncryptedCardNumber = cardPaymentModel.CardNumber;
            var suffixCardNumber = unEncryptedCardNumber.Substring(unEncryptedCardNumber.Length - 4, 4);
            var preFixCard = unEncryptedCardNumber.Substring(0, unEncryptedCardNumber.Length - 4);
            var encryptedCardNumber = AesOperation.EncryptString(this._appSettings.Key, suffixCardNumber);
            var encryptedCvvNumber = AesOperation.EncryptString(this._appSettings.Key, cardPaymentModel.Cvvnumber);

            CardPayment cardPayment = new CardPayment
            {
                Amount = cardPaymentModel.Amount,
                CardHolderName = cardPaymentModel.CardHolderName,
                CardNumber = encryptedCardNumber+ suffixCardNumber,
                Cvvnumber = encryptedCvvNumber,
                DateModified = DateTime.Now,
                ExpiryDate = cardPaymentModel.ExpiryDate,
                Id = cardPaymentModel.Id == null ? Guid.NewGuid().ToString(): cardPaymentModel.Id
            };
            //Insert card details
            this.CardPaymentRepository.Insert(cardPayment);
            unitOfWork.Save();
            return true;
        }

        /// <summary>
        /// This method represents get card details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns
        public IList<CardPaymentModel> GetCardPayments(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var cardDetailsList = this.CardPaymentRepository.Query().Where(a=>a.Id==id).ToList();
                return BindCardPaymentModel(cardDetailsList);
            }
            else
            {
                var cardDetailsList = this.CardPaymentRepository.Query().ToList();
                return BindCardPaymentModel(cardDetailsList);
            }
        }

        /// <summary>
        /// The Bind card payment model
        /// </summary>
        /// <param name="cardDetailsList">The card payment list</param>
        /// <returns></returns>
        private List<CardPaymentModel> BindCardPaymentModel(List<CardPayment> cardDetailsList)
        {
            List<CardPaymentModel> paymentModelList = new List<CardPaymentModel>();
            foreach (var cardDetails in cardDetailsList)
            {
                var cardPayment = new CardPaymentModel
                {
                    Amount = cardDetails.Amount,               
                    CardHolderName = cardDetails.CardHolderName,
                    CardNumber = cardDetails.CardNumber,
                    Cvvnumber = cardDetails.Cvvnumber,
                    DateModified = DateTime.Now,
                    ExpiryDate = cardDetails.ExpiryDate,
                    Id = cardDetails.Id
                };
                paymentModelList.Add(cardPayment);
            }

            return paymentModelList;
        }
    }
}
