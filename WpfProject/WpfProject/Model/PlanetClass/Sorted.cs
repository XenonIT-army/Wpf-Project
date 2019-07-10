using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Interface;

namespace WpfProject.Model.PlanetClass
{
    class SortedName : ISorted
    {
        public ObservableCollection<Planet> Sorted(ObservableCollection<Planet> planets)
        {
          var sortedPlanets = planets.OrderBy(planet => planet.Name);
            planets = new ObservableCollection<Planet>(sortedPlanets);
            return planets;
        }
    }
    class SortedSystem : ISorted
    {
        public ObservableCollection<Planet> Sorted(ObservableCollection<Planet> planets)
        {
            var sortedPlanets = planets.OrderBy(planet => planet.System);
            planets = new ObservableCollection<Planet>(sortedPlanets);
            return planets;
        }
    }
    class SortedGalaxy : ISorted
    {
        public ObservableCollection<Planet> Sorted(ObservableCollection<Planet> planets)
        {
            var sortedPlanets = planets.OrderBy(planet => planet.Galaxy);
            planets = new ObservableCollection<Planet>(sortedPlanets);
            return planets;
        }
    }
    class SortedSize : ISorted
    {
        public ObservableCollection<Planet> Sorted(ObservableCollection<Planet> planets)
        {
            var sortedPlanets = planets.OrderBy(planet => planet.Size);
            planets = new ObservableCollection<Planet>(sortedPlanets);
            return planets;
        }
    }

    public class SortedValue
    {
        public static ObservableCollection<string> GetValue()
        {
            return new ObservableCollection<string>
            {
                "Name",
                "System",
                "Galaxy",
                "Size"

            };
        }

     
    }
}
