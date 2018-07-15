﻿using BitcoinApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
		}
	}
}