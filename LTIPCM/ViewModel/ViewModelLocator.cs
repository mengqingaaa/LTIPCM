/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LTIPCM"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Autofac;
using Autofac.Extras.CommonServiceLocator;

using LTIPCM.Service;
using LTIPCM.Model;

namespace LTIPCM.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        /// 

        private IContainer _container;

        public ViewModelLocator()
        {
            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var builder = new ContainerBuilder();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                //SimpleIoc.Default.Register<IDataAccessService, ServicesDesignTime>();
                builder.RegisterType<ServicesDesignTime>().As<IDataAccessService>().SingleInstance();
            }
            else
            {
                // Create run time view services and models
                //SimpleIoc.Default.Register<IDataAccessService, DataAccessServices>();
                builder.RegisterType<DataAccessServices>().As<IDataAccessService>().SingleInstance();
            }

            //SimpleIoc.Default.Register<IDataAccessService, DataAccessServices>();

            //SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<ClientViewModel>();

            builder.RegisterInstance<ViewModelLocator>(this).SingleInstance();
            builder.RegisterType<MainWindowViewModel>().SingleInstance();
            builder.RegisterType<ClientViewModel>().SingleInstance();
            builder.RegisterType<ClientTabViewModel>();

            _container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(_container));
        }

        //public MainViewModel Main
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<MainViewModel>();
        //    }
        //}

        public MainWindowViewModel MainWindowsViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainWindowViewModel>(); }
        }

        public ClientViewModel ClientViewModel
        {
            get { return ServiceLocator.Current.GetInstance<ClientViewModel>(); }
        }

        public ClientTabViewModel GetClientTabViewModel(Client client)
        {
            return _container.Resolve<ClientTabViewModel>(new NamedParameter("currentClient", client));
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}