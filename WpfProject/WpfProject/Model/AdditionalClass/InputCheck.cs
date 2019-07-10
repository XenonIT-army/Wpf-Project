using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Model.AdditionalClass
{
   public class InputCheck
    {
        public string Check(string inputSymbols)
        {
            bool validA = inputSymbols.All(c => Char.IsNumber(c));
            if (validA == true)
            {
                return inputSymbols;
            }
            else
            return inputSymbols.Remove(inputSymbols.Count()-1);
        }
    }
}
