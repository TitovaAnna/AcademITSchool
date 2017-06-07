using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        private double r;

        public Circle(double r)
        {
            this.r = r;
        }
      
        public override double getWidth()
        {
            return 2 * r;
        }
        public override double getHeight()
        {
            return 2 * r;
        }

        public override double getArea()
        {
            return Math.PI * Math.Pow(r, 2);
        }

        public override double getPerimeter()
        {
            return 2 * Math.PI * r;
        }
    }
}
