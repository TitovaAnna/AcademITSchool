using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : IShape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double GetWidth()
        {
            return length;
        }
        public double GetHeight()
        {
            return width;
        }

        public double GetArea()
        {
            return width * length;
        }

        public double GetPerimeter()
        {
            return 2 * (width + length);
        }

        public override string ToString()
        {
            return string.Format("Прямоугольник со сторонами:{0},{1}", length, width);
        }
        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 17;
            hash = prime * hash + (int)width;
            hash = prime * hash + (int)length;
            return hash;
        }
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }
            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
            {
                return false;
            }
            Rectangle rectangle = (Rectangle)o;
            return (length == rectangle.length) && (width == rectangle.width);
        }
    }
}
