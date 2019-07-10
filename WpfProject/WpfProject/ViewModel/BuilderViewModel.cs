using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfProject.Infrastructure;
using WpfProject.Model.AdditionalClass;
using WpfProject.Model.ImagesClass;
using WpfProject.Model.PlanetClass;

namespace WpfProject.ViewModel
{
    public class BuilderViewModel : Notifier
    {
        ObservableCollection<Planet> planets;
        public ObservableCollection<Planet> searchPlanets;
        private Planet selectedPlanet;
        private Planet _planet = new Planet();
        Search search = new Search();
        Remove removePlanet = new Remove();
        OpenImage openImage = new OpenImage();
        InputCheck inputCheck = new InputCheck();
       

       public BuilderViewModel() { }

        public BuilderViewModel(ObservableCollection<Planet> planets)
        {
            this.planets = planets;
            searchPlanets = new ObservableCollection<Planet>(planets);
           
        }

        #region Property
        public string _imageAddPath = "/Resources/NoImage.png";
        public string _input;
        public string _search;


        public Planet Planet
        {
            get => _planet;
            set
            {
                _planet = value;
                Notify();
            }
        }
        public Planet SelectedPlanet
        {
            get => selectedPlanet;
            set
            {
                selectedPlanet = value;
                Notify();
            }
        }
        public ObservableCollection<Planet> SearchPlanets
        {
            get => searchPlanets = new ObservableCollection<Planet>(planets);
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
        public string ImageAddPath
        {
            get => _imageAddPath;
            set
            {

                _imageAddPath = value;
                Notify();
            }
        }
        public string Input
        {
            get => _input;
            set
            {

                _input = value;

                _input = inputCheck.Check(Input);
                Notify();
            }
        }
        public string Search
        {
            get => _search;
            set
            {
                _search = value;

                if (Search == "")
                    SearchPlanets = planets;
                else
                    SearchPlanets = search.SearchPlanet(planets, _search);
                Notify();
            }
        }
        #endregion


        #region Command
        private ICommand _addImageCommand;
        private ICommand _editImageCommand;
        private ICommand _addPlanetCommand;
        private ICommand _closeCommand;
        private ICommand _deletePlanetCommand;


        public ICommand DeletePlanetCommand
        {
            get
            {
                if (_deletePlanetCommand == null)
                {
                    _deletePlanetCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Planets = removePlanet.RemovePlanet(Planets, selectedPlanet);
                        SearchPlanets = Planets;
                    });
                }
                return _deletePlanetCommand;
            }
            set { _deletePlanetCommand = value; }
        }


        public ICommand AddImageCommand
        {
            get
            {
                if (_addImageCommand == null)
                {
                    _addImageCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Planet.ImagePath = openImage.OpenFileDialog(Planet.ImagePath);
                        ImageAddPath = Planet.ImagePath;
                    });
                }
                return _addImageCommand;
            }
            set { _addImageCommand = value; }
        }

        public ICommand EditImageCommand
        {
            get
            {
                if (_editImageCommand == null)
                {
                    _editImageCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        SelectedPlanet.ImagePath = openImage.OpenFileDialog(SelectedPlanet.ImagePath);
                    });
                }
                return _editImageCommand;
            }
            set { _editImageCommand = value; }
        }

        public ICommand AddPlanetCommand
        {
            get
            {
                if (_addPlanetCommand == null)
                {
                    _addPlanetCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        if (Input != "" && Input != null)
                            Planet.Size = Int64.Parse(Input);

                        planets.Add(Planet);
                        SearchPlanets = new ObservableCollection<Planet>(planets);
                        Planet = new Planet();
                        Input = "";
                        ImageAddPath = "/Resources/NoImage.png";
                    });
                }
                return _addPlanetCommand;
            }
            set { _addPlanetCommand = value; }
        }
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Planet = new Planet();
                        ImageAddPath = "/Resources/NoImage.png";
                    });
                }
                return _closeCommand;
            }
            set { _closeCommand = value; }
        }

        #endregion

    }
}
