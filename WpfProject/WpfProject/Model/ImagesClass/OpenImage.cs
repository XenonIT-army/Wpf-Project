using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Model.ImagesClass
{
    public class OpenImage
    {
        public string OpenFileDialog(string pathImage)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                pathImage= dialog.FileName;
            }
                return pathImage;
        }
    }
}
