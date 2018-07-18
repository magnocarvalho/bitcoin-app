using BitcoinApp.Db;
using BitcoinApp.Model;
using BitcoinApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Repository
{
    public class MarketPriceRepository : BaseRepository, IMarketPriceRepository
    {
        public MarketPriceRepository(Database dbContext) : base(dbContext)
        {
        }

        public MarketPrice Get() => DbContext.GetConnection().Table<MarketPrice>().FirstOrDefault();

        public bool Insert(MarketPrice actualPrice)
        {
            var rs = DbContext.GetConnection().Insert(actualPrice);
            return rs > 0 ? true : false;
        }

        public bool Update(MarketPrice actualPrice)
        {
            var rs = DbContext.GetConnection().Update(actualPrice);
            return rs > 0 ? true : false;
        }
    }
}
