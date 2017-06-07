using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Shape
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public virtual double getWidth()
        {
            return -1;
        }
        public virtual double getHeight()
        {
            return -1;
        }
        public virtual double getArea()
        {
            return -1;
        }
        public virtual double getPerimeter()
        {
            return -1;
        }
    }
}
