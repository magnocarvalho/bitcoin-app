using BitcoinApp.Services;
using BitcoinApp.Services.Interfaces;
using CommonServiceLocator;
using System;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace BitcoinApp
{
	public partial class App : Application
	{
        
		public App ()
		{
			InitializeComponent();
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IActualPriceService, ActualPriceService>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
