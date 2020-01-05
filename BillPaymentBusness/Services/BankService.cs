using PaymentWeb.business;
using BillPaymentBusness.Encryption;
using BillPaymentBusness.Interfaces;
using BillPaymentBusness.Models;
using BillPaymentDataAccess.Repositary;
using BillPaymentDataAccess.UnitOfWork;
using DataAcess.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentBusness.Services
{
    /// <summary>
    /// This class handles all bank services
    /// </summary>
    public class BankService : IBankService
    {
        /// <summary>
        /// The Unit of work
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The bankRepositary
        /// </summary>
        private IRepository<NetBanking> bankRepository;

        /// <summary>
        /// The app settings
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// The constructer for bank service
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork</param>
        /// <param name="appSettings">The appSettings</param>
        public BankService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.bankRepository = unitOfWork.NetBankingRepositary;
            this.unitOfWork = unitOfWork;
            this._appSettings = appSettings.Value;
        }

        /// <summary>
        /// The get bank details
        /// </summary>
        /// <param name="BankModel">The BankModel</param>
        /// <returns>returns bankmodel</returns>
        public BankModel GetBankModel(BankModel bankModel)
        {
            var encryptedUserName = AesOperation.EncryptString(this._appSettings.Key, bankModel.UserName);
            var encryptedpassWord = AesOperation.EncryptString(this._appSettings.Key, bankModel.Password);
            var netBankList = this.bankRepository.Query();

            foreach(var netbank in netBankList)
            {
                if(netbank.UserName== encryptedUserName && netbank.Password == encryptedpassWord)
                {
                    return new BankModel
                    {
                        Amount = netbank.Amount,
                        Id = netbank.Id,
                        Password = netbank.Password,
                        UserName = netbank.UserName,
                        DateModified = netbank.DateModified

                    };
                }
            }

            return null;
        }
    }
}
