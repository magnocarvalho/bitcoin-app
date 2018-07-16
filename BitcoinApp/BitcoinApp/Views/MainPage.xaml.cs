using BitcoinApp.ViewModel;
using Microcharts;
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
            ViewModel = new MainVieWModel();
            BindingContext = ViewModel;

            chartView.Chart = new LineChart
            {
                Entries = ViewModel.Entries,
                PointMode = PointMode.None,
                LineMode = LineMode.Straight
            };
            chartView.Chart.LabelTextSize = 25;
        }

	}
}
