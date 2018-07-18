using BitcoinApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Services.Interfaces
{
    public interface IMarketPriceService
    {
        MarketPrice Get();
        bool Insert(MarketPrice actualPrice);
        bool Update(MarketPrice actualPrice);
    }
}
