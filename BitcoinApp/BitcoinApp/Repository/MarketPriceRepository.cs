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

        public bool Insert(MarketPrice marketPrice)
        {
            int rs = 0;
            rs = DbContext.GetConnection().Insert(marketPrice);
            rs +=  DbContext.GetConnection().Execute("delete from value");
            foreach(var value in marketPrice.Values)
            {
                rs += DbContext.GetConnection().Insert(value);
            }
            return rs > 0 ? true : false;
        }

        public bool Update(MarketPrice marketPrice)
        {
            var rs = DbContext.GetConnection().Update(marketPrice);
            return rs > 0 ? true : false;
        }
    }
}
