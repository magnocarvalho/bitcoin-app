﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    [Table("market_price")]
    public class MarketPrice : BaseEntity
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public List<Value> Values { get; set; }
    }
}
