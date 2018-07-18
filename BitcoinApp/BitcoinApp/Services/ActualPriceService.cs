using BitcoinApp.Db;
using BitcoinApp.Model;
using BitcoinApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Services
{
    public class ActualPriceService : BaseService, IActualPriceService
    {
        public ActualPriceService(Database dbContext) : base(dbContext)
        {
        }

        public bool Exists(int id) => new UnitOfWork(DbContext).ActualPriceRepository.Exists(id);

        public ActualPrice Get() => new UnitOfWork(DbContext).ActualPriceRepository.Get();

        public bool Insert(ActualPrice actualPrice)
        {
            using (var uow = new UnitOfWork(DbContext))
            {
                var rs = uow.ActualPriceRepository.Insert(actualPrice);
                uow.Commit();
                return rs;
            }
        }

        public bool Update(ActualPrice actualPrice)
        {
            using (var uow = new UnitOfWork(DbContext))
            {
                var rs = uow.ActualPriceRepository.Update(actualPrice);
                uow.Commit();
                return rs;
            }
        }
    }
}
