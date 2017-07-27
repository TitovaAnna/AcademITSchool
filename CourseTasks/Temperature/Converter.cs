using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    class Converter
    {
        public static double Convert(Scales.Scale scaleIn, Scales.Scale scaleOut, double value)
        {
            double temp = Scales.TransferToC(scaleIn, value);
            return Scales.TransferFromC(scaleOut, temp);
        }
    }
}
