using BitcoinApp.Helpers;
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
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
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
            IsBusy = false;
        }

        internal void LoadChartData()
        {
            IsBusy = true;
            MarketPrice rs = ApiSync.GetChartValues();
            var entries = new List<Microcharts.Entry>();
            foreach (var price in rs.Values)
            {
                entries.Add(new Microcharts.Entry((float)price.UsdPrice)
                {
                    Color = SKColor.Parse("#003E06"),
                    ValueLabel = GetLabel(price)
                });
            }
            Entries = new ObservableCollection<Microcharts.Entry>(entries);
            IsBusy = false;
        }

        internal void LoadActualPriceData()
        {
            var value = ApiSync.GetActualPrice();
            ActualPrice = String.Format("U$ {0:0.##}", value.UsdPrice);
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
