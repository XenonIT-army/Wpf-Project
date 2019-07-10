using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Model.PlanetClass;

namespace WpfProject.Interface
{
    interface ISorted
    {
        ObservableCollection<Planet> Sorted(ObservableCollection<Planet> planets);
    }
}
