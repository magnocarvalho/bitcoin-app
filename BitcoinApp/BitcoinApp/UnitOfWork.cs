using BitcoinApp.Db;
using BitcoinApp.Repository;
using BitcoinApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp
{
    public class UnitOfWork : IUnitOfWork
    {
        private Database _dbContext;
        private bool _disposed;

        private IActualPriceRepository _actualPriceRepository;
        private IMarketPriceRepository _marketPriceRepository;
        private IValueRepository _valueRepository;

        public UnitOfWork(Database dbContext)
        {
            _dbContext = dbContext;
        }

        public IActualPriceRepository ActualPriceRepository => _actualPriceRepository ?? (_actualPriceRepository = new ActualPriceRepository(_dbContext));
        public IMarketPriceRepository MarketPriceRepository => _marketPriceRepository ?? (_marketPriceRepository = new MarketPriceRepository(_dbContext));
        public IValueRepository ValueRepository => _valueRepository ?? (_valueRepository = new ValueRepository(_dbContext));

        public void Commit()
        {
            _dbContext.GetConnection().Commit();
            ResetRepositories();
        }

        private void ResetRepositories()
        {
            _actualPriceRepository = null;
            _marketPriceRepository = null;
            _valueRepository = null;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                    _disposed = true;
                }
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
