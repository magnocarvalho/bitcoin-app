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

        public bool Exists(int id)
        {
            var rs = DbContext.GetConnection().Get<ActualPrice>(id);
            return rs.Id > 0 ? true : false;
        }

        public ActualPrice Get() => DbContext.GetConnection().Table<ActualPrice>().FirstOrDefault();

        public bool Insert(ActualPrice actualPrice)
        {
            var rs = DbContext.GetConnection().Insert(actualPrice);
            return rs > 0 ? true : false;
        }

        public bool Update(ActualPrice actualPrice)
        {
            var rs = DbContext.GetConnection().Update(actualPrice);
            return rs > 0 ? true : false;
        }
    }
}
