using BitcoinApp.Helpers;
using BitcoinApp.ViewModel;
using Microcharts;
using Microsoft.Practices.ServiceLocation;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace BitcoinApp
{
	public partial class MainPage : ContentPage
	{
        public MainVieWModel ViewModel { get; set; }

        public MainPage()
		{
			InitializeComponent();

            ViewModel =  ServiceLocator.Current.GetInstance<MainVieWModel>();
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadDataExecuteCommand();
        }
    }
}
