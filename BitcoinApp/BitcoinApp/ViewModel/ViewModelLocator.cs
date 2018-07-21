using BitcoinApp.Services;
using BitcoinApp.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.ViewModel
{
    public class ViewModelLocator
    {
        private UnityContainer _unityContainer;

        public MainVieWModel MainVieWModel
        {
            get
            {
                return _unityContainer.Resolve<MainVieWModel>();
            }
        }

        public ViewModelLocator()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<IActualPriceService, ActualPriceService>();
            _unityContainer.RegisterType<IMarketPriceService, MarketPriceService>();
            _unityContainer.RegisterType<MainVieWModel>(new ContainerControlledLifetimeManager());

            UnityServiceLocator unityServiceLocator = new UnityServiceLocator(_unityContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
