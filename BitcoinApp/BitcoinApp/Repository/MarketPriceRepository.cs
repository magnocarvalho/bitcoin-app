using BitcoinApp.Db;
using BitcoinApp.Model;
using BitcoinApp.Repository.Interfaces;
using System.Linq;
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

        public MarketPrice Get()
        {
            var market =  DbContext.GetConnection().Table<MarketPrice>().FirstOrDefault();
            return market;
        }

        public bool Insert(MarketPrice marketPrice)
        {
            int rs = 0;
            DbContext.GetConnection().Execute("delete from market_price");
            DbContext.GetConnection().Execute("delete from market_values");
            rs = DbContext.GetConnection().Insert(marketPrice);
            rs = DbContext.GetConnection().InsertAll(marketPrice.Values);
            
            return rs > 0 ? true : false;
        }
    }
}
