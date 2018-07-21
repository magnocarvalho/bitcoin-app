using BitcoinApp.Model;
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
        public ObservableCollection<ItemList> Items { get; set; }

        public ListValuesPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<ItemList>
            {
                new ItemList {Date = "14/07/2018", Value = "U$ 6235,70", UpDown = "=>"},
                new ItemList {Date = "14/07/2018", Value = "U$ 6235,70", UpDown = "=>"},
                new ItemList {Date = "14/07/2018", Value = "U$ 6235,70", UpDown = "=>"},
                new ItemList {Date = "14/07/2018", Value = "U$ 6235,70", UpDown = "=>"},
                new ItemList {Date = "14/07/2018", Value = "U$ 6235,70", UpDown = "=>"},
                new ItemList {Date = "14/07/2018", Value = "U$ 6235,70", UpDown = "=>"}
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
