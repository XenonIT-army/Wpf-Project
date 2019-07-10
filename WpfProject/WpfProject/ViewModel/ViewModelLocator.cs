using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Ninject;
using System.Collections.ObjectModel;
using System.Windows;
using WpfProject.Data;
using WpfProject.Infrastructure;
using WpfProject.Interface;
using WpfProject.Model.AdditionalClass;
using WpfProject.Model.PlanetClass;

namespace WpfProject.ViewModel
{

    public class ViewModelLocator
    {
        IKernel kernel;
        ObservableCollection<Planet> planets;
        public ViewModelLocator()
        {
            kernel = new StandardKernel();
            kernel.Bind<IIOService<ObservableCollection<Planet>>>().To<JsonService>();
            kernel.Bind<ResourcePath>()
                        .To<ResourcePath>()
                            .WithPropertyValue("Path", "Planets.json");

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<HomeViewModel>();

            Messenger.Default.Register<ObservableCollection<Planet>>(this, InitializationCollection);

            SimpleIoc.Default.Register<BuilderViewModel>(() =>
            {
                return new BuilderViewModel(planets);
            });

            SimpleIoc.Default.Register<PlanetCollectionViewModel>(() =>
            {
                return new PlanetCollectionViewModel(planets);
            });
        }

        private void InitializationCollection(ObservableCollection<Planet> _planet)
        {
            planets = _planet;

        }

        #region Property
        public HomeViewModel HomePage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public PlanetCollectionViewModel PlanetCollection
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlanetCollectionViewModel>();
            }

        }

        public BuilderViewModel Builder
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BuilderViewModel>();
            }
        }
        public MainViewModel MainWindow
        {
            get => kernel.Get<MainViewModel>();
        }
        #endregion

    }
}