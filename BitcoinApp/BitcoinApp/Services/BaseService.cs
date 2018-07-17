using BitcoinApp.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Services
{
    public abstract class BaseService
    {
        protected Database DbContext { get; private set; }

        public BaseService(Database dbContext)
        {
            DbContext = dbContext;
        }
    }
}
