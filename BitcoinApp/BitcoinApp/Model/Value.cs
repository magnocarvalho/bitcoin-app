using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    [Table("market_values")]
    public class Value 
    {
        [JsonProperty("x")]
        public long TimeStamp { get; set; }

        public DateTime FormatedDate { get { return TimeStampConverter(TimeStamp); } }

        [JsonProperty("y")]
        public decimal UsdPrice { get; set; }


        private DateTime TimeStampConverter(double timeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dateTime.AddSeconds(timeStamp).ToLocalTime();
        }
    }
}
