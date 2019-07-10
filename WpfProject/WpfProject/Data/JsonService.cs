using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Interface;
using WpfProject.Model.AdditionalClass;
using WpfProject.Model.PlanetClass;

namespace WpfProject.Data
{
    class JsonService : IIOService<ObservableCollection<Planet>>
    {
        readonly ResourcePath filePath;
        public JsonService(ResourcePath path) => filePath = path;
       

        public void Save(ObservableCollection<Planet> data)
        {
            File.WriteAllText(filePath.Path,
            JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        ObservableCollection<Planet> IIOService<ObservableCollection<Planet>>.Load()
        {
            if (File.Exists(filePath.Path))
                return JsonConvert.DeserializeObject<ObservableCollection<Planet>>(File.ReadAllText(filePath.Path));
            else
            {
                using (FileStream fs = File.Create(filePath.Path)) { }
                return JsonConvert.DeserializeObject<ObservableCollection<Planet>>(File.ReadAllText(filePath.Path));
            }
                
        }
    }
}
