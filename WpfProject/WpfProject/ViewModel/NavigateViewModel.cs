using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfProject.Infrastructure;
using WpfProject.Model.PlanetClass;

namespace WpfProject.ViewModel
{
    public class NavigateViewModel : ViewModelBase
    {
      
        public string Title { get; set; }
        public void Navigate(string url)
        {
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }
        public void MessengCollection(ObservableCollection<Planet> planets)
        {
            Messenger.Default.Send<ObservableCollection<Planet>>(planets);
        }
        public override void Cleanup()
        {
            Messenger.Default.Unregister<ObservableCollection<Planet>>(this);
        }

    }
}
