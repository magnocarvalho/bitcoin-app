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
        List<Entry> entries = new List<Entry>
        {
            new Entry(6.764f) {Color = SKColor.Parse("#003E06"), Label = "Segunda", ValueLabel = "6.764"},
            new Entry(6.780f) {Color = SKColor.Parse("#003E06"), Label = "Terça", ValueLabel = "6.780"},
            new Entry(3.768f) {Color = SKColor.Parse("#003E06"), Label = "Quarta", ValueLabel = "3.768"},
            new Entry(6.736f) {Color = SKColor.Parse("#003E06"), Label = "Quinta", ValueLabel = "6.736"},
            new Entry(6.688f) {Color = SKColor.Parse("#003E06"), Label = "Sexta", ValueLabel = "6.688"},
            new Entry(6.638f) {Color = SKColor.Parse("#003E06"), Label = "Sábado", ValueLabel = "6.638"},
            new Entry(6.564f) {Color = SKColor.Parse("#003E06"), Label = "Domingo", ValueLabel = "6.564"}
        };
        public MainPage()
		{
			InitializeComponent();
            ViewModel = new MainVieWModel();
            BindingContext = ViewModel;
            chartView.Chart = new LineChart { Entries = entries };
            chartView.Chart.LabelTextSize = 25;

        }
	}
}
