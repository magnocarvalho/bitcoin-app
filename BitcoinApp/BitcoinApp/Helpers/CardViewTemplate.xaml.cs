using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Entry = Microcharts.Entry;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BitcoinApp.Helpers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardViewTemplate : ContentView
	{
        List<Entry> entries = new List<Entry>
        {
            new Entry(200) {Color = SKColor.Parse("#003E06"), Label = "Janeiro", ValueLabel = "200"},
            new Entry(400) {Color = SKColor.Parse("#003E06"), Label = "Fevereiro", ValueLabel = "400"},
            new Entry(-100) {Color = SKColor.Parse("#003E06"), Label = "Março", ValueLabel = "-100"}
        };
        public CardViewTemplate ()
		{
			InitializeComponent ();
            chartView.Chart = new LineChart { Entries = entries };
        }
	}
}