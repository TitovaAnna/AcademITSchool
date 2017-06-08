using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetArea()
        {
            return Math.Abs(0.5 * ((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3)));
        }

        public double GetPerimeter()
        {
            return GetLength(x1, y1, x2, y2) + GetLength(x1, y1, x3, y3) + GetLength(x3, y3, x2, y2);
        }
        private static double GetLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        public override string ToString()
        {
            return string.Format("Треугольник с координатами вершин:{0},{1};{2},{3}{4};{5},{6}", x1, y1, x2, y2, x3, y3);
        }
        public override int GetHashCode()
        {
            int hash = 1;
            hash = CalculationHash(x1, hash);
            hash = CalculationHash(x2, hash);
            hash = CalculationHash(x3, hash);
            hash = CalculationHash(y1, hash);
            hash = CalculationHash(y2, hash);
            hash = CalculationHash(y3, hash);
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
            Triangle triangle = (Triangle)o;

            return x1 == triangle.x1 && x2 == triangle.x2 && x3 == triangle.x3 &&
                   y1 == triangle.y1 && y2 == triangle.y2 && y3 == triangle.y3;
        }
        private int CalculationHash(double x, int hash)
        {
            int prime = 17;
            return prime * hash + (int)x;
        }
    }
}
