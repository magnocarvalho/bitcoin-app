using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    public class Value
    {
        [JsonProperty("x")]
        public int TimeStamp { get; set; }
        [JsonProperty("y")]
        public double UsdPrice { get; set; }
    }
}
