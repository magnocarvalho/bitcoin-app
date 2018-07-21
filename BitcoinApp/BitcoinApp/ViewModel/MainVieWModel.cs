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

        private bool _errorMessage;
        public bool ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        public ActualPrice BDActual { get; private set; }
        public MarketPrice BDMarket { get; private set; }

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

        public ActualPrice Actual { get; set; }
        public MarketPrice Market { get; set; }

        public Command LoadDataCommand { get; set; }

        public ObservableCollection<Microcharts.Entry> Entries { get; set; }

        private readonly IActualPriceService _actualPriceService;
        private readonly IMarketPriceService _marketPriceService;

        public MainVieWModel(IActualPriceService actualPriceService, IMarketPriceService marketPriceService)
        {
            _actualPriceService = actualPriceService;
            _marketPriceService = marketPriceService;
            IsBusy = false;
            ErrorMessage = false;
            LoadDataCommand = new Command(LoadDataExecuteCommand);
            LoadDataExecuteCommand();
        }

        internal void LoadDataExecuteCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            ErrorMessage = false;
            BDActual = _actualPriceService.Get();
            BDMarket = _marketPriceService.Get();

            LoadActualPriceData();
            LoadChatData();

            IsBusy = false;
        }

        private void FillActualPrice()
        {
            if (!ObjectIsNull(Actual))
            {
                ActualPrice = String.Format("U$ {0:0.##}", Actual.UsdPrice);
                ActualDate = Actual.FormatedDate.Date.ToString("dd/MM/yyyy");
            }
            else if (!ObjectIsNull(BDActual))
            {
                ActualPrice = String.Format("U$ {0:0.##}", BDActual.UsdPrice);
                ActualDate = BDActual.FormatedDate.Date.ToString("dd/MM/yyyy");
            }
            else
            {
                ActualPrice = "--";
                ActualDate = null;
                ErrorMessage &= true;
                return;
            }
        }

        internal bool LoadActualPriceData()
        {
            if (!ApiSync.HasConnection())
                return false;

            Actual = ApiSync.GetActualPrice();

            FillActualPrice();

            if (ObjectIsNull(Actual))
                return false;

            return _actualPriceService.Insert(Actual);
        }

        internal bool LoadChatData()
        {
            if (!ApiSync.HasConnection())
                return false;

            Market = ApiSync.GetChartValues();

            ValidateChartData();

            if (ObjectIsNull(Market))
                return false;

            return _marketPriceService.Insert(Market);
        }

        private void DrawChart(MarketPrice market)
        {
            var entries = new List<Microcharts.Entry>();
            foreach (var price in market.Values)
            {
                entries.Add(new Microcharts.Entry((float)price.UsdPrice)
                {
                    Color = SKColor.Parse("#003E06"),
                    ValueLabel = price.FormatedDate.Day == 1 ? String.Format("{0:MMM}", price.FormatedDate) : null
                });
            }
            Entries = new ObservableCollection<Microcharts.Entry>(entries);

        }

        internal bool ObjectIsNull<T>(T item)
        {
            if (item == null)
                return true;
            else
                return false;
        }

        internal void ValidateChartData()
        {
            if (!ObjectIsNull(Market))
                DrawChart(Market);
            else if (!ObjectIsNull(BDMarket))
                DrawChart(BDMarket);
            else
            {
                Entries = null;
                ErrorMessage &= true;
                return;
            }
        }
    }
}
