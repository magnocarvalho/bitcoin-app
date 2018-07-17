using BitcoinApp.Db;
using BitcoinApp.Model;
using BitcoinApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Services
{
    public class ActualPriceService : BaseService, IActualPriceService
    {
        public ActualPriceService(Database dbContext) : base(dbContext)
        {
        }

        public ActualPrice Get() => new UnitOfWork(DbContext).ActualPriceRepository.Get();
    }
}
