using System;
using BillPaymentDataAccess.Repositary;
using DataAcess.Models;

namespace BillPaymentDataAccess.UnitOfWork
{
    /// <summary>
    /// The Unit of work hold all repositarys
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// The OperatorPlanRepository
        /// </summary>
        IOperaterRepositary OperatorPlanRepository { get; }

        /// <summary>
        /// The CardPaymentRepository
        /// </summary>
        IRepository<CardPayment> CardPaymentRepository { get; }

        /// <summary>
        /// The NetBankingRepositary
        /// </summary>
        IRepository<NetBanking> NetBankingRepositary { get; }

        /// <summary>
        /// The PostPaidRepository
        /// </summary>
        IRepository<PostPaid> PostPaidRepository { get; }

        /// <summary>
        /// The save 
        /// </summary>
        void Save();
    }
}
