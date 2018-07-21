using BitcoinApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Repository.Interfaces
{
    public interface IValueRepository
    {
        List<Value> Get();
        bool Insert(Value actualPrice);
    }
}
