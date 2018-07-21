﻿using BitcoinApp.Db;
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
            ActualPrice actualPrice = _actualPriceService.Get();
            MarketPrice marketPrice = _marketPriceService.Get();

            if (!ObjectIsNull(actualPrice) && !ObjectIsNull(marketPrice))
            {
                if (!LoadActualPriceData())
                {
                    FillActualPrice(actualPrice);
                }
                if (!LoadChatData())
                {
                    DrawChart(marketPrice);
                }
            }
            else
            {
                if (!LoadActualPriceData())
                {
                    ActualPrice = "--";
                    ActualDate = null;
                    ErrorMessage &= true;
                }
                else
                    FillActualPrice(Actual);

                if (!LoadChatData())
                {
                    Entries = null;
                    ErrorMessage &= true;
                }
                else
                    DrawChart(Market);

            }
            IsBusy = false;
        }

        private void FillActualPrice(ActualPrice actual)
        {
            ActualPrice = String.Format("U$ {0:0.##}", actual.UsdPrice);
            ActualDate = actual.FormatedDate.Date.ToString("dd/MM/yyyy");
        }

        internal bool LoadActualPriceData()
        {
            if (!ApiSync.HasConnection())
                return false;

            Actual = ApiSync.GetActualPrice();
            var _actual = _actualPriceService.Get();

            if (ObjectIsNull(Actual))
                return false;

            return _actualPriceService.Insert(Actual);
        }

        internal bool LoadChatData()
        {
            if (!ApiSync.HasConnection())
                return false;

            Market = ApiSync.GetChartValues();
            var _marketPrice = _marketPriceService.Get();

            if (ObjectIsNull(Market))
                return false;

            return _marketPriceService.Insert(Market);
        }

        private void DrawChart(MarketPrice marketPrice)
        {
            var entries = new List<Microcharts.Entry>();
            foreach (var price in marketPrice.Values)
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
    }
}
