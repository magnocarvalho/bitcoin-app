using BitcoinApp.Model;
using BitcoinApp.Resources;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BitcoinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListValuesPage : ContentPage
    {
        public ListValuesPage()
        {
            InitializeComponent();
            Title = AppResources.DailyHistory;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}
