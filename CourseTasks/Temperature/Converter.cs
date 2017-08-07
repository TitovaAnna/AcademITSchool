using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    class Converter
    {
        public static double Convert(IScales scaleIn, IScales scaleOut, double value)
        {
            double temp = scaleIn.TransferToC(value);
            return scaleOut.TransferFromC(temp);
        }
    }
}
