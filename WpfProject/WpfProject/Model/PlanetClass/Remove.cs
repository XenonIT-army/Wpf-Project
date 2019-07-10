using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Model.PlanetClass
{
   
    class Remove 
    {
        public ObservableCollection<Planet> RemovePlanet(ObservableCollection<Planet> planets,Planet remove)
        {
            planets.Remove(remove);
            return planets;
        }
    }
}
