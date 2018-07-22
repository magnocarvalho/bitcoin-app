using BitcoinApp.Helpers;
using BitcoinApp.Model;
using BitcoinApp.Resources;
using BitcoinApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BitcoinApp.ViewModel
{
    public class ListViewModel
    {
        IMarketPriceService _marketPriceService;
        IActualPriceService _actualPriceService;
        public ObservableCollection<ItemList> ListValues { get; set; }
        public Command LoadDataCommand { get; set; }
        public ListViewModel(IMarketPriceService marketPriceService, IActualPriceService actualPriceService)
        {
            _marketPriceService = marketPriceService;
            _actualPriceService = actualPriceService;
            LoadDataCommand = new Command(LoadDataExecuteCommand);
            LoadDataExecuteCommand();
        }

        public bool IsBusy { get; private set; }
        public bool ErrorMessage { get; private set; }
        public MarketPrice DbMarket { get; private set; }
        public ActualPrice DbActual { get; private set; }
        public ActualPrice Actual { get; private set; }
        public MarketPrice Market { get; private set; }

        void LoadDataExecuteCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            ErrorMessage = false;
            DbMarket = _marketPriceService.Get();

            LoadValueData();
            ValidateValueData();

            IsBusy = false;
        }

        private bool LoadValueData()
        {
            if (!ApiSync.HasConnection())
                return false;

            Market = ApiSync.GetMarketValues();
            return true;
        }

        private void ValidateValueData()
        {
            if (!ObjectIsNull(Market))
                FillList(Market);
            else if (!ObjectIsNull(DbMarket))
                FillList(DbMarket);
            else
            {
                ErrorMessage = true;
                return;
            }
        }

        private void FillList(MarketPrice market)
        {
            var listValues = new List<ItemList>();
            for (int i = 0; i < market.Values.Count; i++)
            {
                if (i == 0)
                {
                    listValues.Add(new ItemList
                    {
                        FormatedDate = market.Values[i].FormatedDate.Date.ToString(AppResources.FormatedDate),
                        UsdPrice = String.Format("U$ {0:0.##}", market.Values[i].UsdPrice),
                        UpDown = "ic_square"
                    });
                }
                else
                {
                    listValues.Add(new ItemList
                    {
                        FormatedDate = market.Values[i].FormatedDate.Date.ToString(AppResources.FormatedDate),
                        UsdPrice = String.Format("U$ {0:0.##}", market.Values[i].UsdPrice),
                        UpDown = market.Values[i].UsdPrice > market.Values[i - 1].UsdPrice ? "ic_arrow_up_thick" : "ic_arrow_down_thick"
                    });
                }
            }
            listValues.Reverse();
            ListValues = new ObservableCollection<ItemList>(listValues);
        }

        private bool ObjectIsNull<T>(T item)
        {
            if (item == null)
                return true;
            else
                return false;
        }
    }
}
