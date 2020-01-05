using BillPaymentBusness.Models;
using System.Collections.Generic;

namespace BillPaymentBusness.Interfaces
{
    /// <summary>
    /// This class represents IOperatorService
    /// </summary>
    public interface IOperatorService
    {
        /// <summary>
        /// This method to get recharge plans
        /// </summary>
        /// <returns></returns>
        List<RechargePlans> GetAllPrepaidPlans();
        
        /// <summary>
        /// The method to represents  insert recharge plan
        /// </summary>
        /// <param name="operaterModel"></param>
        /// <returns></returns>
        bool InsertRechargePlan(RechargePlans operaterModel);

        /// <summary>
        /// This method get recharge details by operater
        /// </summary>
        /// <param name="operater">The operater</param>
        /// <returns></returns>
        List<RechargePlans> GetRechargePlansByOperater(string operater);
    }
}
