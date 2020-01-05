using Moq;
using System.Collections.Generic;
using Xunit;
using PaymentWeb.Controllers;
using BillPaymentBusness.ExceptionHandler;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using BillPaymentBusness.Services;
using BillPaymentDataAccess.UnitOfWork;
using DataAcess.Models;
using Microsoft.Extensions.Logging;

namespace BillPaymentWebTest
{
    public class PaymentControllerTest
    {
        private LoggerFactory _logger;
        private IPaymentService _paymentService;

        /// <summary>
        /// This method validates card payment
        /// </summary>
        [Fact]
        public void MakeCardPaymentTestIsSucessFully()
        {
            //Arrange
            Options options = new Options();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            List<CardPayment> cardPaymentList = new List<CardPayment>();
            var cardpaymentModel = new CardPayment();
            cardpaymentModel.CardNumber = "123456777889";
            cardpaymentModel.Cvvnumber = "123";
            cardpaymentModel.CardHolderName = "test";
            cardpaymentModel.Amount = 60;

            var cardPaymentModelList = new List<CardPaymentModel>();
            var cardpayment = new CardPaymentModel();
            cardpayment.CardNumber = "123456777889";
            cardpayment.Cvvnumber = "123";
            cardpayment.CardHolderName = "test";
            cardpayment.Amount = 60;


            cardPaymentList.Add(cardpaymentModel);
            unitOfWorkMock.Setup(m => m.CardPaymentRepository.Query(null, null, 1, 0, null)).Returns(cardPaymentList);
            _paymentService = new PaymentService(unitOfWorkMock.Object, options); 
            
            //Act
            var paymentController = new PaymentController(_paymentService);
            var result = paymentController.MakeCardPayment(cardpayment);

            //Assert
            Assert.True(result.Status);
        }


        [Fact]
        public void ValidateMakeCardPaymentTestFailed()
        {
            Options options = new Options();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            List<CardPayment> cardPaymentList = new List<CardPayment>();
            var cardpaymentModel = new CardPayment();
              cardpaymentModel.Cvvnumber = "123";
            cardpaymentModel.CardHolderName = "test";
            cardpaymentModel.Amount = 60;


            var cardPaymentModelList = new List<CardPaymentModel>();
            var cardpayment = new CardPaymentModel();
            //cardpayment.CardNumber = "123456777889";
            cardpayment.Cvvnumber = "123";
            cardpayment.CardHolderName = "test";
            cardpayment.Amount = 20;


            cardPaymentList.Add(cardpaymentModel);
            unitOfWorkMock.Setup(m => m.CardPaymentRepository.Query(null, null, 1, 0, null)).Returns(cardPaymentList);
            _paymentService = new PaymentService(unitOfWorkMock.Object, options);
            var paymentController = new PaymentController(_paymentService);

            try
            {
                var result = paymentController.MakeCardPayment(null);
            }
            catch(BusinessException ex)
            {
                Assert.Equal("CardPayment details is null", ex.Message);
            }
                      
        }

        /// <summary>
        /// This method is Make 
        /// </summary>
        [Fact]
        public void MakeBankPaymentSucessFully()
        {
            //Arrange
            Options options = new Options();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            List<NetBanking> netModelList = new List<NetBanking>();
            var netBankingModel = new NetBanking();
            netBankingModel.UserName = "Test";
            netBankingModel.Password = "Test";

            netBankingModel.Amount = 60;
            netModelList.Add(netBankingModel);


            List<BankModel> bankModelList = new List<BankModel>();
            var bankModel = new BankModel();
            bankModel.UserName = "Test";
            bankModel.Password = "Test";
            bankModel.Amount = 10;
            bankModelList.Add(bankModel);                                   
            unitOfWorkMock.Setup(m => m.NetBankingRepositary.Query(null, null, 1, 0, null)).Returns(netModelList);           
            _paymentService = new PaymentService(unitOfWorkMock.Object, options);

            //Act
            var paymentController = new PaymentController(_paymentService);
            var result = paymentController.MakeBankPayment(bankModel);

            //Assert
            Assert.True(result.Status);
        }
    }
}
