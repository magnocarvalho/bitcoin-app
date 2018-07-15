using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BitcoinApp.ViewModel
{
    public class MainVieWModel : BaseViewModel
    {
        public IList<CardDataModel> CardDataCollection { get; set; }

        public object SelectedItem { get; set; }

        public MainVieWModel()
        {
            CardDataCollection = new List<CardDataModel>();
            GenerateCardModel();
        }

        private void GenerateCardModel()
        {
            for (int i = 0; i < 1; i++)
            {
                var cardData = new CardDataModel()
                {
                    Title = "Anything"
                };
            CardDataCollection.Add(cardData);
            }
        }
    }

    public class CardDataModel
    {
        public string Title { get; set; }
    }
}
