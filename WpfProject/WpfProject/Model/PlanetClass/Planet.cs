using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Infrastructure;

namespace WpfProject.Model.PlanetClass
{
    [Serializable]
    public class Planet : Notifier
    {
        public string Name { get; set; }
        public string System { get; set; }
        public string Galaxy { get; set; }
        private string imagePath = "/Resources/NoImage.png";
        public string Description { get; set; }
        public double Size { get; set; }
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                Notify();
            }

        }
    }
}
