using Moq;
using System.Collections.Generic;
using Xunit;
using PaymentWeb.Controllers;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Services;
using BillPaymentDataAccess.UnitOfWork;
using DataAcess.Models;
using Microsoft.Extensions.Logging;

namespace PaymentWebUnitTest
{
    public class OperaterControllerTest
    {
        private LoggerFactory _logger;
        private IOperatorService _operaterService;
        [Fact]
        public void GetOperaterListTest()
        {

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.OperatorPlanRepository.GetOperatorList())
                      .Returns(new List<OperaterTable> {
                    new OperaterTable{ Operater="Airtel"
                            }
              });

            _operaterService = new OperatorService(unitOfWorkMock.Object);
            // _logger = (LoggerFactory)new LoggerFactory().CreateLogger("OperatorController");

            //    Mock<ILogger<OperatorController>>  loggerMock = new  Mock<ILogger<OperatorController>>();
            var operateraController = new OperatorController(_operaterService);

            var result = operateraController.GetAllRechargePlans();
            Assert.NotNull(result);
        }
    }
}
