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

        public ActualPrice DbActual { get; private set; }
        public MarketPrice DbMarket { get; private set; }

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

        private void LoadDataExecuteCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            ErrorMessage = false;
            DbActual = _actualPriceService.Get();
            DbMarket = _marketPriceService.Get();

            LoadActualPriceData();
            ValidateActualPriceData();
            LoadChatData();
            ValidateChartData();

            IsBusy = false;
        }

        private void FillActualPrice(ActualPrice actual)
        {
            ActualPrice = String.Format("U$ {0:0.##}", actual.UsdPrice);
            ActualDate = actual.FormatedDate.Date.ToString("dd/MM/yyyy");
        }

        private bool LoadActualPriceData()
        {
            if (!ApiSync.HasConnection())
                return false;

            Actual = ApiSync.GetActualPrice();


            if (ObjectIsNull(Actual))
                return false;

            return _actualPriceService.Insert(Actual);
        }

        private bool LoadChatData()
        {
            if (!ApiSync.HasConnection())
                return false;

            Market = ApiSync.GetChartValues();


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

        private bool ObjectIsNull<T>(T item)
        {
            if (item == null)
                return true;
            else
                return false;
        }

        private void ValidateChartData()
        {
            if (!ObjectIsNull(Market))
                DrawChart(Market);
            else if (!ObjectIsNull(DbMarket))
                DrawChart(DbMarket);
            else
            {
                Entries = null;
                ErrorMessage &= true;
                return;
            }
        }

        private void ValidateActualPriceData()
        {
            if (!ObjectIsNull(Actual))
                FillActualPrice(Actual);
            else if (!ObjectIsNull(DbActual))
                FillActualPrice(DbActual);
            else
            {
                ActualPrice = "--";
                ActualDate = null;
                ErrorMessage &= true;
                return;
            }
        }
    }
}
