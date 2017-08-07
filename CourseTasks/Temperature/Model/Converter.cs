using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Converter
    {
        public static double Convert(IScale scaleIn, IScale scaleOut, double value)
        {
            double temp = scaleIn.TransferToC(value);
            return scaleOut.TransferFromC(temp);
        }
    }
}
