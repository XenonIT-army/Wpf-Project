using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.Infrastructure;
using WpfProject.Model;
using WpfProject.Model.ImagesClass;

namespace WpfProject.ViewModel
{
    public class HomeViewModel : Notifier
    {

        MainImages mainImages = new MainImages();

        public HomeViewModel()
        {
            images = mainImages.GetImagesNext();

        }

        #region Property

        string images;

        public string Images
        {
            get => images;
            set
            {
                images = value;
                Notify();
            }

        }
        #endregion

        #region Command
        private ICommand _mainImageCommandNext;
        private ICommand _mainImageCommandBack;


        public ICommand MainImageCommandNext
        {
            get
            {
                if (_mainImageCommandNext == null)
                {
                    _mainImageCommandNext = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Images = mainImages.GetImagesNext();


                    });
                }
                return _mainImageCommandNext;
            }
            set { _mainImageCommandNext = value; }
        }
        public ICommand MainImageCommandBack
        {
            get
            {
                if (_mainImageCommandBack == null)
                {
                    _mainImageCommandBack = new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        Images = mainImages.GetImagesBack();


                    });
                }
                return _mainImageCommandBack;
            }
            set { _mainImageCommandBack = value; }
        }

        #endregion
    }
}
