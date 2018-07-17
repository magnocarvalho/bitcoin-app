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

        private const string SQL_BASE = @"select * from actual_price";
        public ActualPriceRepository(Database dbContext) : base(dbContext)
        {
        }

        public ActualPrice Get() => DbContext.GetConnection().Table<ActualPrice>().FirstOrDefault();
    }
}
