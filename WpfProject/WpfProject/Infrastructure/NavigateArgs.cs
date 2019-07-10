using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Infrastructure
{
    class NavigateArgs
    {
        public NavigateArgs(string url)
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}
