using BitcoinApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp
{
    public interface IUnitOfWork : IDisposable
    {
        IActualPriceRepository ActualPriceRepository { get; }
        IMarketPriceRepository MarketPriceRepository { get; }
        IValueRepository ValueRepository { get; }

        void Commit();
    }
}
