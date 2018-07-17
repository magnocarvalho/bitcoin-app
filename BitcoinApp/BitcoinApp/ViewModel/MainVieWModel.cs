using BitcoinApp.Db;
using BitcoinApp.Helpers;
using BitcoinApp.Model;
using BitcoinApp.Services.Interfaces;
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

        private string _actualDate;
        public string ActualDate
        {
            get { return _actualDate; }
            set { SetProperty(ref _actualDate, value); }
        }

        public ObservableCollection<Microcharts.Entry> Entries { get; set; }

        private readonly IActualPriceService _actualPriceService;

        public MainVieWModel(IActualPriceService actualPriceService)
        {
            _actualPriceService = actualPriceService;
            IsBusy = false;
        }

        internal void LoadData()
        {
            IsBusy = true;
            ActualPrice actualPrice;
            actualPrice = _actualPriceService.Get();
            if (actualPrice != null)
            {
                if(actualPrice.FormatedDate.Date.Date == DateTime.Now.Date.Date)
                {
                    LoadActualPriceData();
                }

            }
            if (Helpers.ApiSync.HasConnection())
            {
                MarketPrice rs = ApiSync.GetChartValues();
                if (rs == null)
                    return;

                var entries = new List<Microcharts.Entry>();
                foreach (var price in rs.Values)
                {
                    entries.Add(new Microcharts.Entry((float)price.UsdPrice)
                    {
                        Color = SKColor.Parse("#003E06"),
                        ValueLabel = price.FormatedDate.Day == 1 ? String.Format("{0:MMM}", price.FormatedDate) : null
                    });
                }
                Entries = new ObservableCollection<Microcharts.Entry>(entries); 
            }
            IsBusy = false;
        }

        internal void LoadActualPriceData()
        {
            var actual = ApiSync.GetActualPrice();
            ActualPrice = String.Format("U$ {0:0.##}", actual.UsdPrice);
            ActualDate = actual.FormatedDate.Date.ToString("dd/MM/yyyy");
        }
    }
}
