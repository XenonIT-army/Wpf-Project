using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using WPFLocalizeExtension.Engine;
using WpfProject.Infrastructure;
using WpfProject.Interface;
using WpfProject.Model.AdditionalClass;
using WpfProject.Model.PlanetClass;
using WpfProject.Model.Theme;

namespace WpfProject.ViewModel
{ 
    public class MainViewModel : NavigateViewModel
    {
        public ObservableCollection<Planet> planets = new ObservableCollection<Planet>();
        IIOService<ObservableCollection<Planet>> inOutService;
        Theme theme = new Theme();
        public MainViewModel(IIOService<ObservableCollection<Planet>> inOutService)
        {
            planets = inOutService.Load();
            if(planets==null)
                planets = new ObservableCollection<Planet>();
            this.inOutService = inOutService;
            MessengCollection(planets);
            theme.AddTheme();
        }

        #region Property
        private int index = 1;
        public int Index
        {
            get => index;
            set
            {

                index = 1;

            }
        }
        #endregion

        #region Command
        private ICommand _homePageCommand;
        private ICommand _categoryPageCommand;
        private ICommand _builderPageCommand;
        private ICommand _closeProjectCommand;
        private ICommand _themeCommand;

        public ICommand ThemeCommand
        {
            get
            {
                if (_themeCommand == null)
                {
                    _themeCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        theme.NextTheme();
                    });
                }
                return _themeCommand;
            }
            set { _themeCommand = value; }
        }

        public ICommand PlanetCollectionCommand
        {
            get
            {
                if (_categoryPageCommand == null)
                {
                    _categoryPageCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Navigate("Views/PlanetCollection.xaml");
                    });
                }
                return _categoryPageCommand;
            }
            set { _categoryPageCommand = value; }
        }

        public ICommand BuilderPageCommand
        {
            get
            {
                if (_builderPageCommand == null)
                {
                    _builderPageCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Navigate("Views/Builder.xaml");
                    });
                }
                return _builderPageCommand;
            }
            set { _builderPageCommand = value; }
        }

        public ICommand HomePageCommand
        {
            get
            {
                if (_homePageCommand == null)
                {
                    _homePageCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Navigate("Views/HomePage.xaml");
                    });
                }
                return _homePageCommand;
            }
            set { _homePageCommand = value; }
        }

        public ICommand CloseProjectCommand
        {
            get
            {
                if (_closeProjectCommand == null)
                {
                    _closeProjectCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        inOutService.Save(planets);
                        Properties.Settings.Default.Save();
                    });
                }
                return _closeProjectCommand;
            }
            set { _closeProjectCommand = value; }
        }
        #endregion

    }
}