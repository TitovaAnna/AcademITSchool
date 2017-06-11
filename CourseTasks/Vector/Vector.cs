using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private double[] components;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new IllegalArgumentException("Размерность вектора должна быть больше 0");
            }
            components = new double[n];
        }

        public Vector(Vector vector)
        {
            int length = vector.components.Length;
            components = new double[length];
            Array.Copy(vector.components, components, length);
        }

        public Vector(double[] components)
        {
            int length = components.Length;
            this.components = new double[length];
            for (int i = 0; i < length; i++)
            {
                this.components[i] = components[i];
            }
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0)
            {
                throw new IllegalArgumentException("Размерность вектора должна быть больше 0");
            }

            this.components = new double[n];
            for (int i = 0; i < components.Length; i++)
            {
                this.components[i] = components[i];
            }
        }

        public int GetSize()
        {
            return components.Length; ;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(components[0]);
            for (int i = 1; i < components.Length; i++)
            {
                sb.AppendFormat(",{0}", components[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (vector.components.Length != components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != vector.components[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 0;
            for (int i = 0; i < components.Length; i++)
            {
                hash = prime * hash + (int)components[i];
            }
            return hash;
        }

        public void Add(Vector vector)
        {
            Vector vectorCopy = new Vector(vector);
            int max = Math.Max(vector.components.Length, components.Length);

            if (components.Length < max)
            {
                Array.Resize(ref components, max);
            }
            else if (vector.components.Length < max)
            {
                Array.Resize(ref vectorCopy.components, max);
            }
            for (int i = 0; i < max; i++)
            {
                components[i] = components[i] + vectorCopy.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            int max = Math.Max(vector.components.Length, components.Length);
            Vector vectorCopy = new Vector(vector);
            if (components.Length < max)
            {
                Array.Resize(ref components, max);
            }
            else if (vector.components.Length < max)
            {
                Array.Resize(ref vectorCopy.components, max);
            }
            for (int i = 0; i < max; i++)
            {
                components[i] = components[i] - vectorCopy.components[i];
            }
        }

        public void MultiplyScalar(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = scalar * components[i];
            }
        }

        public void Inverse()
        {
            MultiplyScalar(-1);
        }

        public double GetLength()
        {
            double quadraticSum = 0;

            foreach (double component in components)
            {
                quadraticSum += Math.Pow(component, 2);
            }
            return Math.Sqrt(quadraticSum);
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponent(double component, int index)
        {
            components[index] = component;
        }

        public static Vector GetVectorSum(Vector vector1, Vector vector2)
        {
            Vector vectorCopy1 = new Vector(vector1);
            Vector vectorCopy2 = new Vector(vector2);
            vectorCopy1.Add(vectorCopy2);
            return vectorCopy1;
        }

        public static Vector GetVectorDifference(Vector vector1, Vector vector2)
        {
            Vector vectorCopy1 = new Vector(vector1);
            Vector vectorCopy2 = new Vector(vector2);
            vectorCopy1.Subtract(vectorCopy2);
            return vectorCopy1;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            Vector vectorCopy1 = new Vector(vector1);
            Vector vectorCopy2 = new Vector(vector2);

            int length1 = vectorCopy1.components.Length;
            int length2 = vectorCopy1.components.Length;
            int max = Math.Max(length1, length2);

            if (length1 < max)
            {
                Array.Resize(ref vectorCopy1.components, max);
            }
            else if (length2 < max)
            {
                Array.Resize(ref vectorCopy2.components, max);
            }

            double scalar = 0;
            for (int i = 0; i < max; i++)
            {
                scalar += vectorCopy1.components[i] * vectorCopy2.components[i];
            }
            return scalar;
        }
    }
}
