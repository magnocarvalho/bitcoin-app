using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    [Table("Value")]
    public class Value : BaseEntity
    {
        [JsonProperty("x")]
        public long TimeStamp { get; set; }

        public DateTime FormatedDate { get { return TimeStampConverter(TimeStamp); } }

        public int MarketPriceId { get; set; }

        [JsonProperty("y")]
        public decimal UsdPrice { get; set; }


        private DateTime TimeStampConverter(double timeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
