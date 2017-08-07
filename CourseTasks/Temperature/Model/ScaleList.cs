using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Temperature;

namespace Model
{
    class ScaleList
    {
        public static List<IScale> GetListScale()
        {
            List<IScale> scaleList = new List<IScale>() { new Kelvin(), new Celsius(), new Fahrenheit() };
            return scaleList;
        }
    }
}
