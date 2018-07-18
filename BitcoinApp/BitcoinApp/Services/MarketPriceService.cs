using BitcoinApp.Db;
using BitcoinApp.Model;
using BitcoinApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Services
{
    public class MarketPriceService : BaseService, IMarketPriceService
    {
        public MarketPriceService(Database dbContext) : base(dbContext)
        {
        }

        public MarketPrice Get() => new UnitOfWork(DbContext).MarketPriceRepository.Get();

        public bool Insert(MarketPrice actualPrice)
        {
            using (var uow = new UnitOfWork(DbContext))
            {
                var rs = uow.MarketPriceRepository.Insert(actualPrice);
                uow.Commit();
                return rs;
            }
        }

        public bool Update(MarketPrice actualPrice)
        {
            using (var uow = new UnitOfWork(DbContext))
            {
                var rs = uow.MarketPriceRepository.Update(actualPrice);
                uow.Commit();
                return rs;
            }
        }
    }
}
