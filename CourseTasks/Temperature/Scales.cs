using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    class Scales
    {
        public enum Scale
        {
            Celsium = 0,
            Kelvin = 1,
            Fahrenheit = 2
        }
        public static double TransferToC(Scale scale, double valueIn)
        {
            if (scale == Scale.Fahrenheit)
            {
                return (valueIn - 32) * 5 / 9;
            }
            else if (scale == Scale.Kelvin)
            {
                return valueIn - 273.15;
            }
            return valueIn;
        }
        public static double TransferFromC(Scale scale, double valueIn)
        {
            if (scale == Scale.Fahrenheit)
            {
                return valueIn * 9 / 5 + 32;
            }
            else if (scale == Scale.Kelvin)
            {
                return valueIn + 273.15;
            }
            return valueIn;
        }
    }
}
