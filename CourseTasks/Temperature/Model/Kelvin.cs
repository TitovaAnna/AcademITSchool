﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Kelvin : IScale
    {
        public double TransferToC(double valueIn)
        {
            return valueIn - 273.15;
        }
        public double TransferFromC(double valueIn)
        {
            return valueIn + 273.15;
        }
        public override string ToString()
        {
            return "Градус Кельвина";
        }
    }
}
