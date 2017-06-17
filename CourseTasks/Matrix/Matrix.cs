using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector;

namespace Matrix
{
    class Matrix
    {
        private Vector.Vector[] components;

        public Matrix(int n, int m)
        {
            if ((n <= 0) || (m <= 0))
            {
                throw new Vector.IllegalArgumentException("Размеры матрицы  должны быть больше 0");
            }

            components = new Vector.Vector[m];
            for (int i = 0; i < m; i++)
            {
                components[i] = new Vector.Vector(n);
            }
        }

        public Matrix(double[,] components) //double[,] mas = new int[3, 3] { { 4, 7, 3 }, { 3, 6, 9 }, { 0, 1, 4 } };  int[][] MyMas = new int[4][];
        {

            this.components = new Vector.Vector[components.GetLength(0)];
            for (int i = 0; i < components.GetLength(0); i++)
            {
                double[] array = new double[components.GetLength(1)];
                for (int j = 0; j < components.GetLength(1); j++)
                {
                    array[j] = components[i, j];
                }
                Vector.Vector vector = new Vector.Vector(array);
                this.components[i] = vector;
            }
        }

        public Matrix(Vector.Vector[] components)
        {
            int length = components.Length;
            this.components = new Vector.Vector[length];
            Array.Copy(components, this.components, length);
        }

        public Matrix(Matrix matrix) : this(matrix.components)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{{");
            sb.Append(components[0].GetComponent(0));
            for (int j = 1; j < components[0].GetSize(); j++)
            {
                sb.Append(", ");
                sb.Append(components[0].GetComponent(j));
            }
            sb.Append("}");

            for (int i = 1; i < components.Length; i++)
            {
                sb.Append(", {");
                sb.Append(components[i].GetComponent(0));
                for (int j = 1; j < components[i].GetSize(); j++)
                {
                    sb.Append(", ");
                    sb.Append(components[i].GetComponent(j));
                }
                sb.Append("}");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public int Size(int index)
        {
            if ((index != 0) && (index != 1))
            {
                throw new IllegalArgumentException("Индекс должен быть равен 0 или 1");
            }
            if (index == 0)
            {
                return components[0].GetSize();
            }
            return components.Length;
        }

        public Vector.Vector GetRow(int index)
        {
            return components[index];
        }

        public void SetRow(Vector.Vector vector, int index)
        {
            components[index] = vector;
        }

        public Vector.Vector GetColumn(int index)
        {
            if (index > components[0].GetSize())
            {
                throw new IllegalArgumentException("Индекс не может быть больше длины вектора");
            }
            double[] array = new double[components.Length];
            for (int i = 0; i < components.Length; i++)
            {
                for (int j = 0; j < components[0].GetSize(); j++)
                {
                    if (j == index)
                    {
                        array[i] = components[i].GetComponent(j);
                    }
                }
            }
            return new Vector.Vector(array);
        }
        public void Transposition()
        {
            for (int i = 0; i < components[0].GetSize(); i++)
            {
                components[i] = GetColumn(i);
            }
        }

        public void MultiplyScalar(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].MultiplyScalar(scalar);
            }
        }

        public int Determinant()
        {
            if (components.Length != components[0].GetSize())
            {
                throw new IllegalArgumentException("Необходима квадратная матрица для расчета определител");
            }
            int length = components.Length;
            double[,] array = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = components[i].GetComponent(j);
                }
            }
            double det = 0;
            for (int k = 0; k < length; k++)
            {
                det += MinorSearch(array, k);
            }
            Console.WriteLine(det);
            Console.ReadKey();
            return 1;

        }
        private double MinorSearch(double[,] array, int k)
        {
            int length = array.GetLength(0);
            double[,] minor = new double[length - 1, length - 1];
            //   double Sum = 0;
            //for (int k = 0; k < length; k++)
            //{
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (j < k)
                    {
                        minor[i, j] = array[i + 1, j];
                    }
                    else
                    {
                        minor[i, j] = array[i + 1, j + 1];
                    }
                }
            }
            if (minor.Length == 2)
            {
                double determinant = minor[1, 1] * minor[2, 2] - minor[1, 2] * minor[2, 1];
                return determinant;//  double dop = Math.Pow(-1,k)*k * determinant;
            }
        
             //   for (int i = 0; i < minor.Length; i++)
              //  {
                    return Math.Pow(-1, k) * k * MinorSearch(minor, k);
               // }
          
            //Matrix matr = new Matrix(minor);
            //Console.WriteLine(matr.ToString());
            //Console.ReadKey();
            //     }
        }
    }
}
