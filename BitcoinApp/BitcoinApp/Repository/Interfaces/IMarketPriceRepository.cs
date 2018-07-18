using BitcoinApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Repository.Interfaces
{
    public interface IMarketPriceRepository
    {
        MarketPrice Get();
        bool Insert(MarketPrice actualPrice);
        bool Update(MarketPrice actualPrice);
    }
}
