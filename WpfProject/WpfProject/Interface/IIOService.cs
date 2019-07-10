using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Interface
{
    public interface IIOService<T>
    {
        void Save(T data);
        T Load();
    }
}
