using BitcoinApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Services.Interfaces
{
    public interface IMarketPriceService
    {
        MarketPrice Get();
        List<Value> GetValues();
        bool Insert(MarketPrice actualPrice);
    }
}
