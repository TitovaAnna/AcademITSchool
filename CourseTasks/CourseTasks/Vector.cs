using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTasks
{
    class Vector
    {
        private int n;
        private double[] array;

        public Vector(int n)
        {

            if (n < 0)
            {
                throw new IllegalArgumentException("Размерность вектора не может быть отрицательной");
            }
            this.n = n;
        }

        public Vector(Vector vector)
        {
            array = new double[vector.array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = vector.array[i];
            }
            n = vector.n;
        }

        public Vector(double[] array)
        {
            n = array.Length;
            this.array = new double[n];
            for (int i = 0; i < n; i++)
            {
                this.array[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            if (n < 0)
            {
                throw new IllegalArgumentException("Размерность вектора не может быть отрицательной");
            }

            this.n = n;
            this.array = new double[n];
            if (array.Length < n)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    this.array[i] = array[i];
                }
            }

        }

        public int GetSize()
        {
            return n;
        }

        public override string ToString()
        {
            string vectorToString = array[0].ToString();
            for (int i = 1; i < array.Length; i++)
            {
                vectorToString += string.Format(",{0}", array[i]);
            }
            return string.Format("{0}{1}{2}", "{", vectorToString, "}");
        }

        public override bool Equals(object obj)
        {
            Vector vector = (Vector)obj;
            if (vector.n != n)
            {
                return false;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != vector.array[i])
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
            for (int i = 0; i < array.Length; i++)
            {
                hash = prime * hash + (int)array[i];
            }
            return hash;
        }

        public void AddVector(Vector vector)
        {
            int max = Math.Max(vector.array.Length, array.Length);
            if (array.Length < max)
            {
                Array.Resize(ref array, max);
            }
            else if (vector.array.Length < max)
            {
                Array.Resize(ref vector.array, max);
            }
            for (int i = 0; i < max; i++)
            {
                array[i] = array[i] + vector.array[i];
            }
        }

        public void SubtractVector(Vector vector)
        {
            int max = Math.Max(vector.array.Length, array.Length);

            if (array.Length < max)
            {
                Array.Resize(ref array, max);
            }
            else if (vector.array.Length < max)
            {
                Array.Resize(ref vector.array, max);
            }
            for (int i = 0; i < max; i++)
            {
                array[i] = array[i] - vector.array[i];
            }
        }

        public void MultiplyScalar(double scalar)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = scalar * array[i];
            }
        }

        public void Expand(double scalar)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * (-1);
            }
        }

        public double GetLength()
        {
            double quadraticSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                quadraticSum += Math.Pow(array[i], 2);
            }
            return Math.Sqrt(quadraticSum);
        }

        public double GetComponent(int index)
        {
            return array[index];
        }

        public void SetComponent(double component, int index)
        {
            array[index] = component;
        }

        public static Vector GetVectorSum(Vector vector1, Vector vector2)
        {
            int max = Math.Max(vector1.array.Length, vector2.array.Length);
            double[] sumArray = new double[max];
            if (vector2.array.Length < max)
            {
                Array.Resize(ref vector2.array, max);
            }
            else if (vector1.array.Length < max)
            {
                Array.Resize(ref vector1.array, max);
            }
            for (int i = 0; i < max; i++)
            {
                sumArray[i] = vector1.array[i] + vector2.array[i];
            }
            return new Vector(sumArray);
        }

        public static Vector GetVectorDifference(Vector vector1, Vector vector2)
        {
            int max = Math.Max(vector1.array.Length, vector2.array.Length);
            double[] subArray = new double[max];

            if (vector2.array.Length < max)
            {
                Array.Resize(ref vector1.array, max);
            }
            else if (vector1.array.Length < max)
            {
                Array.Resize(ref vector1.array, max);
            }

            for (int i = 0; i < max; i++)
            {
                subArray[i] = vector1.array[i] - vector2.array[i];
            }
            return new Vector(subArray);
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double scalar = 0;

            for (int i = 0; i < vector1.array.Length; i++)
            {
                scalar += vector1.array[i] * vector2.array[i];
            }
            return scalar;
        }
    }
}
