using BitcoinApp.Db;
using BitcoinApp.Model;
using BitcoinApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Repository
{
    public class ActualPriceRepository : BaseRepository, IActualPriceRepository
    {
        public ActualPriceRepository(Database dbContext) : base(dbContext)
        {
        }

        public ActualPrice Get() => DbContext.GetConnection().Table<ActualPrice>().FirstOrDefault();

        public bool Insert(ActualPrice actualPrice)
        {
            int rs = 0;
            DbContext.GetConnection().Execute("delete from actual_price");
            rs = DbContext.GetConnection().Insert(actualPrice);
            return rs > 0 ? true : false;
        }
    }
}
