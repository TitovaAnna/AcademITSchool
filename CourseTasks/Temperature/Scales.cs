using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    interface IScales
    {
        double TransferToC(double valueIn);
        double TransferFromC(double valueIn);
    }
}
