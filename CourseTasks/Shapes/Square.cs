using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : Shape
    {
        private double length;

        public Square(double length)
        {
            this.length = length;
        }

        public override double getWidth()
        {
            return length;
        }
        public override double getHeight()
        {
            return length;
        }

        public override double getArea()
        {
            return Math.Pow(length, 2);
        }
        public override double getPerimeter()
        {
            return 4 * length;
        }
    }
}
