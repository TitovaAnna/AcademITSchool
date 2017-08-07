using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Temperature
{
    class ScaleList
    {
        public static List<IScales> GetListScale()
        {
            IScales celsius = new Celsius();
            IScales kelvin = new Kelvin();
            IScales fahrenheit = new Fahrenheit();
            List<IScales> scaleList = new List<IScales>();
            scaleList.Add(celsius);
            scaleList.Add(kelvin);
            scaleList.Add(fahrenheit);
            return scaleList;
        }
    }
}
