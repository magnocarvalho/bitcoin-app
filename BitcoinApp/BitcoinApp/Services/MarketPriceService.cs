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

        public MarketPrice Get()
        {
            var uow = new UnitOfWork(DbContext);
            var market = uow.MarketPriceRepository.Get();
            if (market != null)
                market.Values = GetValues();
            return market;
        }

        public List<Value> GetValues() => new UnitOfWork(DbContext).ValueRepository.Get();

        public bool Insert(MarketPrice actualPrice)
        {
            var uow = new UnitOfWork(DbContext);
            var rs = uow.MarketPriceRepository.Insert(actualPrice);

            return rs;
        }

    }
}
