using BitcoinApp.Helpers;
using BitcoinApp.Resources;
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
        private const string UPDATE_CHART_VIEW = "UPDATE_CHART_VIEW";
        private const string LOAD_DATA = "LOAD_DATA";
        public MainPage()
        {
            InitializeComponent();
            lblInternetProblem.Text = AppResources.InternetProblem;
            btnMoreInfo.Text = AppResources.MoreInformation;

            MessagingCenter.Subscribe<MainVieWModel, Chart>(this, UPDATE_CHART_VIEW, (sender, chart) =>
            {
                chartView.Chart = chart;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send<MainPage>(this, LOAD_DATA);
        }
    }
}
