using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Celsius : IScale
    {
        public double TransferToC(double valueIn)
        {
            return valueIn;
        }
        public double TransferFromC(double valueIn)
        {
            return valueIn;
        }
        public override string ToString()
        {
            return "Градус Цельсия";
        }
    }
}
