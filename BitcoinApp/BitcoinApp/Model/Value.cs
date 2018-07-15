using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    public class Value
    {
        [JsonProperty("x")]
        public long TimeStamp { get; set; }
        [JsonProperty("y")]
        public decimal UsdPrice { get; set; }
    }
}
