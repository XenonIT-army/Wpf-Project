using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Model.PlanetClass
{
    public class Search 
    {
        private ObservableCollection<Planet> searchPlanets = new ObservableCollection<Planet>();
        public ObservableCollection<Planet> SearchPlanet(ObservableCollection<Planet> planets, string search)
        {
            try
            {


                foreach (var planet in planets)
                {
                    if (planet.Name.Contains(search) == true ||
                        planet.System.Contains(search) == true ||
                        planet.Galaxy.Contains(search) == true ||
                        Convert.ToString(planet.Size).Contains(search) == true)
                    {

                        searchPlanets.Add(planet);
                    }
                }
            }
            catch (Exception)
            {
                return planets;
            }

            planets = searchPlanets;
            searchPlanets = new ObservableCollection<Planet>();
            return planets;
        }
    }
}
