using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    class Fahrenheit : IScales
    {
        public double TransferToC(double valueIn)
        {
            return (valueIn - 32) * 5 / 9;
        }
        public double TransferFromC(double valueIn)
        {
            return valueIn * 9 / 5 + 32;
        }
        public override string ToString()
        {
            return "Градус Фаренгейта";
        }
    }
}
