using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Interface;
using WpfProject.Model.AdditionalClass;
using WpfProject.Model.PlanetClass;

namespace WpfProject.Data
{
    class FileService : IIOService<ObservableCollection<Planet>>
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream;
        readonly ResourcePath filePath;
        public FileService(ResourcePath path) => filePath = path;
       
        public void Save(ObservableCollection<Planet> data)
        {
            stream = new FileStream(filePath.Path, FileMode.Open, FileAccess.Write);
                formatter.Serialize(stream, data);
            stream.Close();
        }

        ObservableCollection<Planet> IIOService<ObservableCollection<Planet>>.Load()
        {
            if (File.Exists(filePath.Path))
            {
                using (stream = new FileStream(filePath.Path, FileMode.Open, FileAccess.Read))
                {
                    return (ObservableCollection<Planet>)formatter.Deserialize(stream);
                }
            }
            else
            {
                stream = new FileStream(filePath.Path, FileMode.Create);
                stream.Close();
                return new ObservableCollection<Planet>();
            }
        }
    }
}
