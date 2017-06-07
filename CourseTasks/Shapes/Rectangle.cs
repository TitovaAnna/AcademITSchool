using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override double getWidth()
        {
            return length;
        }
        public override double getHeight()
        {
            return width;
        }

        public override double getArea()
        {
            return width * length;
        }

        public override double getPerimeter()
        {
            return 2 * (width + length);
        }
    }
}
