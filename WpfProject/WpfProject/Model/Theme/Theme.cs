using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfProject.Model.Theme
{
    class Theme
    {
        private static int count = Properties.Settings.Default.ThemeCount;
        public List<ResourceDictionary> darkTheme = new List<ResourceDictionary>
        {
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml")},
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml")},
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Grey.xaml")},
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml")},
        };

        public List<ResourceDictionary> lightTheme = new List<ResourceDictionary>
        {
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml")},
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml")},
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml")},
            new ResourceDictionary {Source=new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml")},
        };
        public void AddTheme()
        {
            if(count==1)
            {
                foreach (var theme in darkTheme)
                    Application.Current.Resources.MergedDictionaries.Remove(theme);
                foreach (var theme in lightTheme)
                    Application.Current.Resources.MergedDictionaries.Add(theme);
            }
        }

        public void NextTheme()
        {
            if(count==0)
            {
                foreach (var theme in darkTheme)
                    Application.Current.Resources.MergedDictionaries.Remove(theme);
                foreach (var theme in lightTheme)
                    Application.Current.Resources.MergedDictionaries.Add(theme);
                count = 1;
            }
            else
            {
                foreach (var theme in lightTheme)
                    Application.Current.Resources.MergedDictionaries.Remove(theme);
                foreach (var theme in darkTheme)
                    Application.Current.Resources.MergedDictionaries.Add(theme);
                count = 0;
            }
            Properties.Settings.Default.ThemeCount = count;
        }
    }
}
