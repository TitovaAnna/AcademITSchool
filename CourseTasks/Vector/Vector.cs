using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class Vector
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

        public Vector(Vector vector) : this(vector.components)
        {
        }

        public Vector(double[] components)
        {
            int length = components.Length;
            this.components = new double[length];
            Array.Copy(components, this.components, length);
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0)
            {
                throw new IllegalArgumentException("Размерность вектора должна быть больше 0");
            }
            this.components = new double[n];
            int length = components.Length;
            int min = Math.Min(length, n);
            Array.Copy(components, this.components, min);
        }

        public int GetSize()
        {
            return components.Length;
        }


        public double this[int i]
        {
            get
            {
                if (i >= this.GetSize())
                {
                    throw new ArgumentOutOfRangeException("Слишком большой индекс");
                }
                return components[i];
            }
            set
            {
                if (i >= this.GetSize())
                {
                    throw new ArgumentOutOfRangeException("Слишком большой индекс");
                }
                components[i] = value;
            }
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            Vector vectorCopy1 = new Vector(vector1);
            vectorCopy1.Add(vector2);
            return vectorCopy1;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            Vector vectorCopy1 = new Vector(vector1);
            vectorCopy1.Subtract(vector2);
            return vectorCopy1;
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            if (((object)vector1 == null) || (object)vector2 == null)
            {
                return false;
            }
            return vector1.Equals(vector2);
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            if (((object)vector1 == null) || (object)vector2 == null)
            {
                return false;
            }
            return !vector1.Equals(vector2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(components[0]);
            for (int i = 1; i < components.Length; i++)
            {
                sb.Append(", ");
                sb.Append(components[i]);
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
            int lengthVector = vector.components.Length;
            int length = components.Length;

            if (length < lengthVector)
            {
                Array.Resize(ref components, lengthVector);
            }
            for (int i = 0; i < lengthVector; i++)
            {
                components[i] += vector.components[i];
            }
        }


        public void Subtract(Vector vector)
        {
            int lengthVector = vector.components.Length;
            int length = components.Length;
            if (length < lengthVector)
            {
                Array.Resize(ref components, lengthVector);
            }
            for (int i = 0; i < lengthVector; i++)
            {
                components[i] -= vector.components[i];
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
            vectorCopy1.Add(vector2);
            return vectorCopy1;
        }

        public static Vector GetVectorDifference(Vector vector1, Vector vector2)
        {
            Vector vectorCopy1 = new Vector(vector1);
            vectorCopy1.Subtract(vector2);
            return vectorCopy1;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            int min = Math.Min(vector1.components.Length, vector2.components.Length);

            double scalar = 0;
            for (int i = 0; i < min; i++)
            {
                scalar += vector1.components[i] * vector2.components[i];
            }
            return scalar;
        }
    }
}
