using System;
using System.Collections.Generic;
using System.Linq;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using BillPaymentDataAccess;
using BillPaymentDataAccess.UnitOfWork;

namespace BillPaymentBusness.Services
{
    /// <summary>
    /// This class OperatorService 
    /// </summary>
    public class OperatorService : IOperatorService
    {
        /// <summary>
        /// The Unit of work
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The bankRepositary
        /// </summary>
        private IOperaterRepositary operaterRepositary;

        /// <summary>
        /// The OperatorService
        /// </summary>
        /// <param name="unitOfWork">TheunitOfWork </param>
        public OperatorService(IUnitOfWork unitOfWork)
        {
            this.operaterRepositary = unitOfWork.OperatorPlanRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// This method represents All prepaid plans
        /// </summary>
        /// <returns></returns>
        public List<RechargePlans> GetAllPrepaidPlans()
        {
            List<RechargePlans> rechargePlanslist = new List<RechargePlans>();
            var operaterModelList = this.operaterRepositary.GetOperatorList();

            foreach (var rechargePlan in operaterModelList)
            {
                var plan = new RechargePlans { Data = rechargePlan.Data,
                    Descriptions = rechargePlan.Descriptions,
                    Id = rechargePlan.Id,
                    Mrp = rechargePlan.Mrp,
                    Operater = rechargePlan.Operater
                    , Roaming = rechargePlan.Roaming,
                    Sms = rechargePlan.Sms,
                    ValidateDays = rechargePlan.ValidateDays
                };
                rechargePlanslist.Add(plan);
            }

            return rechargePlanslist;
        }

        public bool InsertRechargePlan(RechargePlans operaterModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method used to get recharge plan by operater
        /// </summary>
        /// <param name="operater"></param>
        /// <returns></returns>
        public List<RechargePlans> GetRechargePlansByOperater(string operater)
        {
            List<RechargePlans> rechargePlanslist = new List<RechargePlans>();
           var operaterModelList = this.operaterRepositary.GetOperatorList();

            var rechargeList = (from recharge in operaterModelList
                               where recharge.Operater == operater
                               select recharge).ToList();

            foreach (var rechargePlan in rechargeList)
            {
                var plan = new RechargePlans
                {
                    Data = rechargePlan.Data,
                    Descriptions = rechargePlan.Descriptions,
                    Id = rechargePlan.Id,
                    Mrp = rechargePlan.Mrp,
                    Operater = rechargePlan.Operater,                 
                    Roaming = rechargePlan.Roaming,
                    Sms = rechargePlan.Sms,
                    ValidateDays = rechargePlan.ValidateDays
                };
                rechargePlanslist.Add(plan);
            }

            return rechargePlanslist;
        }
    }
}
