using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfProject.Model.ImagesClass;

namespace WpfProject.Model
{
    class MainImages
    {
        List<Images> images = new List<Images>
        {
            new Images{ PhotoPath="/Resources/Collection1.jpg"},
              new Images{ PhotoPath="/Resources/Collection2.jpg"},
               new Images{ PhotoPath="/Resources/Collection3.jpg"},
                new Images{ PhotoPath="/Resources/Collection4.jpg"},
                 new Images{ PhotoPath="/Resources/Collection5.jpg"},
                  new Images{ PhotoPath="/Resources/Collection6.jpg"},
                   new Images{ PhotoPath="/Resources/Collection7.jpg"},
                    new Images{ PhotoPath="/Resources/Collection8.jpg"},
                     new Images{ PhotoPath="/Resources/Collection9.jpg"},
                      new Images{ PhotoPath="/Resources/Collection10.jpg"}
        };
      
        private int counter = 0;
        public string GetImagesNext()
        {
            
            counter++;
            if (counter > images.Count-1)
                counter = 0;
            return images[counter].PhotoPath;
          
        }
        public string GetImagesBack()
        {

            counter--;
            if (counter < 0)
                counter = images.Count - 1;
            return images[counter].PhotoPath;

        }


    }
}
