using BitcoinApp.Model;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinApp.Helpers
{
    public class ApiSync
    {
        public static MarketPrice GetChartValues()
        {
            var url = "https://api.blockchain.info/charts/market-price?timespan=6months";
            var client = new HttpClient();
            var apiResult = client.GetStringAsync(url);
            var charValues = JsonConvert.DeserializeObject<MarketPrice>(apiResult.Result);
            return charValues;
        }

        public static ActualPrice GetActualPrice()
        {
            var url = "https://api.blockchain.info/stats";
            var client = new HttpClient();
            var apiResult = client.GetStringAsync(url);
            var actualPrice = JsonConvert.DeserializeObject<ActualPrice>(apiResult.Result);
            actualPrice.FormatedDate = DateTime.Now;
            //var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(apiResult.Result);
            //var value = new Value();
            //value.TimeStamp = long.Parse(GetValue(jsonData, "timestamp").ToString());
            //value.UsdPrice = decimal.Parse(GetValue(jsonData, "market_price_usd").ToString());
            return actualPrice; 
        }

        public static bool HasConnection() =>  CrossConnectivity.Current.IsConnected;

        protected static object GetValue(Dictionary<string, object> lst, string key)
        {
            var k = lst.Keys.SingleOrDefault(kAux => kAux.ToLower() == key.ToLower());
            return k == null ? null : lst[k];
        }
    }
}
