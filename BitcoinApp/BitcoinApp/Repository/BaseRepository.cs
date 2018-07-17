using BitcoinApp.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Repository
{
    public abstract class BaseRepository
    {
        protected Database DbContext { get; private set; }

        public BaseRepository(Database dbContext)
        {
            DbContext = dbContext;
        }
    }
}
