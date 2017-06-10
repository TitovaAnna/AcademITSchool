using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTasks
{
    class IllegalArgumentException : Exception
    {
        public IllegalArgumentException(string message) : base(message)   {  }
    }
}
