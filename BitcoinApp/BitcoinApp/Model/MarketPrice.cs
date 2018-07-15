using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    public class MarketPrice
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public List<Value> Values { get; set; }
    }
}
