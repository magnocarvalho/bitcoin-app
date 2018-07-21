using BitcoinApp.Db;
using BitcoinApp.Model;
using BitcoinApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Repository
{
    public class ValueRepository : BaseRepository, IValueRepository
    {
        public ValueRepository(Database dbContext) : base(dbContext)
        {
        }

        public List<Value> Get() => DbContext.GetConnection().Query<Value>("select * from market_values");

        public bool Insert(Value value)
        {
            int rs = 0;
            DbContext.GetConnection().Execute("delete from market_values");
            rs = DbContext.GetConnection().Insert(value);
            return rs > 0 ? true : false;
        }
    }
}
