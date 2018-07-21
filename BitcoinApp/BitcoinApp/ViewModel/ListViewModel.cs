using BitcoinApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.ViewModel
{
    public class ListViewModel
    {
        IMarketPriceService _marketPriceService;
        public ListViewModel(IMarketPriceService marketPriceService)
        {
            marketPriceService = _marketPriceService;
        }
    }
}
