using BitcoinApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Repository.Interfaces
{
    public interface IActualPriceRepository
    {
        ActualPrice Get();
    }
}
