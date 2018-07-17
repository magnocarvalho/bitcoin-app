using BitcoinApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Services.Interfaces
{
    public interface IActualPriceService
    {
        ActualPrice Get();
    }
}
