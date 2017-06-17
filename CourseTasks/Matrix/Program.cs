using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 4);
            Console.WriteLine(matrix.ToString());
            Console.ReadKey();

            double[,] array1 = new double[3, 3] { { 4, 7, 3 }, { 3, 6, 9 }, { 0, 1, 4 } };
            Matrix matrix1 = new Matrix(array1);
            Console.WriteLine(matrix1.ToString());
            Console.ReadKey();

            matrix1.Determinant();


            Vector.Vector[] vectorArray = { new Vector.Vector(new double[3] { 1, 2, 3 }), new Vector.Vector(new double[3] { 4, 7, 9 }) };
            Matrix matrix2 = new Matrix(vectorArray);
            Console.WriteLine(matrix2.ToString());
            Console.ReadKey();

            Matrix matrixCopy = new Matrix(matrix1);
            Console.WriteLine(matrixCopy.ToString());
            Console.ReadKey();

            try
            {
                Console.WriteLine("{0}-{1}", matrix1.Size(0), matrix1.Size(1));
                Console.ReadKey();
            }
            catch (IllegalArgumentException)
            {
                Console.WriteLine("Индекс должен быть равен 0 или 1");
                Console.ReadKey();
            }

            try
            {
                Vector.Vector vector = matrix1.GetColumn(1);
                Console.WriteLine(vector.ToString());
                Console.ReadKey();
            }
            catch (IllegalArgumentException)
            {
                Console.WriteLine("Индекс не может быть больше длины вектора");
                Console.ReadKey();
            }

            //  Vector.Vector vector = matrix1.GetColumn(1);
            matrix1.Transposition();
            Console.WriteLine(matrix1.ToString());
            matrix1.MultiplyScalar(2);

            Console.WriteLine(matrix1.ToString());
            Console.ReadKey();

           


        }
    }
}
