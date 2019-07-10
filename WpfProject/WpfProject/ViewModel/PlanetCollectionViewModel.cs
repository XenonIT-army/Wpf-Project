using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using WpfProject.Infrastructure;
using WpfProject.Interface;
using WpfProject.Model.PlanetClass;

namespace WpfProject.ViewModel
{
    public class PlanetCollectionViewModel :Notifier
    {
        ISorted sortedName = new SortedName();
        ISorted sortedSystem = new SortedSystem();
        ISorted sortedGalaxy = new SortedGalaxy();
        ISorted sortedSize = new SortedSize();
        Search search = new Search();
        Remove removePlanet = new Remove();
        public Planet selectedPlanet;
        public ObservableCollection<Planet> searchPlanets;
        public ObservableCollection<Planet> planets;
        ObservableCollection<string> sortedList = SortedValue.GetValue();

        public PlanetCollectionViewModel() { }
        public PlanetCollectionViewModel(ObservableCollection<Planet> planets)
        {
            this.planets = planets;
            SearchPlanets = new ObservableCollection<Planet>(planets);
           
        }

        #region Property
        public string _search;
        public string _sorted;

        public ObservableCollection<string> SortedList
        {
            get => sortedList;
            set
            {
                sortedList = value;
                Notify();
            }
        }

        public ObservableCollection<Planet> SearchPlanets
        {
            get => searchPlanets;
            set
            {
                searchPlanets = value;
                Notify();
            }
        }

        public ObservableCollection<Planet> Planets
        {
            get => planets;
            set
            {
                planets = value;
                Notify();
            }
        }
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                Notify();
            }
        }


        public string Sorted
        {
            get => _sorted;
            set
            {
                _sorted = value;
                Notify();
            }

        }

        #endregion


        #region Command
        private ICommand _clearsearchCommand;
        private ICommand _searchCollectionCommand;
        private ICommand _sortedNameCollectionCommand;
        private ICommand _searchPlanetCommand;
        private ICommand _sortedPlanetCommand;

        public ICommand SortedPlanetCommand
        {
            get
            {
                if (_sortedPlanetCommand == null)
                {
                    _sortedPlanetCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        if (Sorted == "Name")
                            SearchPlanets = sortedName.Sorted(planets);
                        if (Sorted == "System")
                            SearchPlanets = sortedSystem.Sorted(planets);
                        if (Sorted == "Galaxy")
                            SearchPlanets = sortedGalaxy.Sorted(planets);
                        if (Sorted == "Size")
                            SearchPlanets = sortedSize.Sorted(planets);
                    });
                }
                return _sortedPlanetCommand;
            }
            set { _sortedPlanetCommand = value; }
        }

        public ICommand SearchPlanetCommand
        {
            get
            {
                if (_searchPlanetCommand == null)
                {
                    _searchPlanetCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        if (Search == "")
                            SearchPlanets = planets;
                        else
                        {
                            SearchPlanets = search.SearchPlanet(planets, Search);
                        }
                    });
                }
                return _searchPlanetCommand;
            }
            set { _searchPlanetCommand = value; }
        }

        public ICommand SortedNameCollectionCommand
        {
            get
            {
                if (_sortedNameCollectionCommand == null)
                {
                    _sortedNameCollectionCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        SearchPlanets = sortedName.Sorted(planets);
                    });
                }
                return _sortedNameCollectionCommand;
            }
            set { _sortedNameCollectionCommand = value; }
        }


        public ICommand ClearsearchCommand
        {

            get
            {
                if (_clearsearchCommand == null)
                {
                    _clearsearchCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        SearchPlanets = Planets;
                        Search = "";
                        Sorted = "";
                    });
                }
                return _clearsearchCommand;
            }
            set { _clearsearchCommand = value; }
        }

        public ICommand SearchCollectionCommand
        {
            get
            {
                if (_searchCollectionCommand == null && Search != null)
                {
                    _searchCollectionCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        SearchPlanets = search.SearchPlanet(planets, Search);

                    });
                }
                return _searchCollectionCommand;
            }
            set { _searchCollectionCommand = value; }
        }
        #endregion
        
    }
}
