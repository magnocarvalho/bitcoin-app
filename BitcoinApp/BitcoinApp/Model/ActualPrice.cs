using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    [Table("actual_price")]
    public class ActualPrice : BaseEntity
    {
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [Ignore]
        public DateTime FormatedDate { get; set; }

        [JsonProperty("market_price_usd")]
        public decimal UsdPrice { get; set; }

    }
}
