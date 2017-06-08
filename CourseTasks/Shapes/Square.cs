using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : IShape
    {
        private double length;

        public Square(double length)
        {
            this.length = length;
        }

        public double GetWidth()
        {
            return length;
        }

        public double GetHeight()
        {
            return length;
        }

        public double GetArea()
        {
            return Math.Pow(length, 2);
        }

        public double GetPerimeter()
        {
            return 4 * length;
        }

        public override string ToString()
        {
            return string.Format("Квадрат со стороной:{0}", length);
        }
        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 17;
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
            Square square = (Square)o;
            return (length == square.length);
        }
    }
}
