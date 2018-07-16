using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Db
{
    public interface IDbConfig
    {
        string DBPath { get; }
    }
}
