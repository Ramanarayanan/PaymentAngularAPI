using System;
using BillPaymentDataAccess.Repositary;
using DataAcess.Models;

namespace BillPaymentDataAccess.UnitOfWork
{
    /// <summary>
    /// This method reprsents Unit of work 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private paymentsContext _context;
        private IOperaterRepositary operatorRepository;
        private IRepository<NetBanking> netBankingRepository;
     
        private IRepository<CardPayment> cardPaymentRepository;
        private IRepository<PostPaid> postPaidRepository;

        public UnitOfWork(string connectionString)
        {
            _context = new paymentsContext(connectionString);
        }

        /// <summary>
        /// Allows class to be created using DBContext injected by application
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(paymentsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The NetBankingRepositary
        /// </summary>
        public IRepository<NetBanking> NetBankingRepositary
        {
            get
            {
                if (netBankingRepository == null)
                {
                    netBankingRepository = new Repository<NetBanking>(_context);
                }
                return netBankingRepository;
            }
        }

        /// <summary>
        /// The CardPaymentRepository
        /// </summary>
        public IRepository<CardPayment> CardPaymentRepository
        {
            get
            {
                if (cardPaymentRepository == null)
                {
                    cardPaymentRepository = new Repository<CardPayment>(_context);
                }
                return cardPaymentRepository;
            }
        }

        /// <summary>
        /// The OperatorPlanRepository
        /// </summary>
        public IOperaterRepositary OperatorPlanRepository
        {
            get
            {
                if (operatorRepository == null)
                {
                    operatorRepository = new OperatorRepositary(_context);
                }
                return operatorRepository;
            }
        }

        /// <summary>
        /// The PostPaidRepository
        /// </summary>
        public IRepository<PostPaid> PostPaidRepository
        {
            get
            {
                if (postPaidRepository == null)
                {
                    postPaidRepository = new Repository<PostPaid>(_context);
                }
                return postPaidRepository;
            }
        }

        /// <summary>
        /// aThe save
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
