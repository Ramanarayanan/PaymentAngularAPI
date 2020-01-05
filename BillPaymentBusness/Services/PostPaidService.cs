using System.Collections.Generic;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using BillPaymentDataAccess.Repositary;
using BillPaymentDataAccess.UnitOfWork;
using DataAcess.Models;

namespace BillPaymentBusness.Services
{

    /// <summary>
    /// This class represents PostPaidService
    /// </summary>
    public class PostPaidService : IPostPaidService
    {
        /// <summary>
        /// The Unit of work
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The postPaidRepositary
        /// </summary>
        private IRepository<PostPaid> postPaidRepository;

        /// <summary>
        /// The PostPaidService Constructer
        /// </summary>
        /// <param name="unitOfWork"></param>
        public PostPaidService(IUnitOfWork unitOfWork)
        {
            this.postPaidRepository = unitOfWork.PostPaidRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// This method represents to get all post paids
        /// </summary>
        /// <returns></returns>
        public IList<PostPaidModel> GetAllPostPaidModel()
        {
            List<PostPaidModel> postPaidModelList = new List<PostPaidModel>();
            var postPaidDetails = this.postPaidRepository.Query();
            foreach(var postPaid in postPaidDetails)
            {
                var postpPaidModel = new PostPaidModel
                {
                    Amount = postPaid.Amount,
                    BillType = postPaid.BillType,
                    ConsumerNo = postPaid.ConsumerNo,
                    DateModified = postPaid.DateModified,
                    Id = postPaid.Id,
                    MobileNumber = postPaid.MobileNumber,
                    PaidAmount = postPaid.PaidAmount,
                    ProductId = postPaid.ProductId
                };
                postPaidModelList.Add(postpPaidModel);

            }
            return postPaidModelList;
        }
    }
}
