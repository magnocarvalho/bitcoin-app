using BitcoinApp.Model;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BitcoinApp.ViewModel
{
    public class MainVieWModel : BaseViewModel
    {
        private bool _isRefresing;
        public bool IsRefreshing
        {
            get { return _isRefresing; }
            set { SetProperty(ref _isRefresing, value); }
        }

        private string _actualPrice;
        public string ActualPrice
        {
            get { return _actualPrice; }
            set { SetProperty(ref _actualPrice, value); }
        }


        public ObservableCollection<Microcharts.Entry> Entries { get; set; }
        public MainVieWModel()
        {
            //Entries = new ObservableCollection<Microcharts.Entry>();
            IsRefreshing = false;
            GetData();
        }

        public async void GetData()
        {
            IsRefreshing = true;
            var url = "https://api.blockchain.info/charts/market-price?timespan=6months";
            var client = new HttpClient();
            var result = client.GetStringAsync(url);
            var rs = JsonConvert.DeserializeObject<MarketPrice>(result.Result);
            //rs.Values.Reverse();
            List<Microcharts.Entry> entries = new List<Microcharts.Entry>();
            ActualPrice = rs.Values.LastOrDefault().UsdPrice.ToString();
            foreach (var price in rs.Values)
            {
                entries.Add(new Microcharts.Entry((float)price.UsdPrice)
                {
                    Color = SKColor.Parse("#003E06"),
                    //Label = GetLabel(price)
                    ValueLabel = GetLabel(price)
                });
            }
            Entries = new ObservableCollection<Microcharts.Entry>(entries);
            IsRefreshing = false;
        }

        private static string GetLabel(Value price)
        {
            switch (price.TimeStamp)
            {
                case 1530403200:
                    return "Jul";
                case 1527811200:
                    return "Jun";
                case 1525132800:
                    return "Mai";
                case 1522540800:
                    return "Abr";
                case 1519862400:
                    return "Mar";
                case 1517443200:
                    return "Fev";
                case 1514764800:
                    return "Jan";
                default:
                    return null;
            }
        }
    }
}
