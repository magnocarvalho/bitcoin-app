using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    public class Value
    {
        [JsonProperty("x")]
        public long TimeStamp { get; set; }

        //[Ignore]
        //public DateTime FormatedDate => TimeStampConverter(TimeStamp);

        [JsonProperty("y")]
        public decimal UsdPrice { get; set; }


        private DateTime TimeStampConverter(long timeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
