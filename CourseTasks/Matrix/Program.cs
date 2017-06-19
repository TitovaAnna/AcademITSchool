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

            double[,] arrayMultipy1 = new double[3, 2] { { 4, 7 }, { 6, 9 }, { 1, 4 } };
            Matrix matrixMultiply1 = new Matrix(arrayMultipy1);

            double[,] arrayMultiply2 = new double[2, 3] { { 4, 7, 3 }, { 3, 6, 9 } };
            Matrix matrixMultiply2 = new Matrix(arrayMultiply2);
            Console.WriteLine(matrixMultiply1.Multiply(matrixMultiply2).ToString());
            Console.ReadKey();

            Matrix matrix = new Matrix(3, 4);
            Console.WriteLine(matrix.ToString());
            Console.ReadKey();

            double[,] array1 = new double[3, 3] { { 4, 7, 3 }, { 3, 6, 9 }, { 0, 1, 4 } };
            Matrix matrix1 = new Matrix(array1);
            Console.WriteLine(matrix1.ToString());
            Console.ReadKey();

            try
            {
                matrix1.MultiplyVector(new Vector.Vector(new double[] { 2, 3, 4 }));
                Console.WriteLine(matrix1);
                Console.ReadKey();
            }

            catch (InvalidOperationException)
            {
                Console.WriteLine("Размерность вектора должна совпадать с количество столбцов матрицы");
                Console.ReadKey();
            }
            try
            {
                double determinant = matrix1.GetDeterminant();
                Console.WriteLine(determinant);
                Console.ReadKey();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Матрица должна быть квадратной");
                Console.ReadKey();
            }


            Vector.Vector[] vectorArray = { new Vector.Vector(new double[3] { 1, 2, 3 }), new Vector.Vector(new double[3] { 4, 7, 9 }), new Vector.Vector(new double[3] { 4, 7, 9 }) };
            Matrix matrix2 = new Matrix(vectorArray);
            Console.WriteLine(matrix2.ToString());
            Console.ReadKey();

            Matrix matrixCopy = new Matrix(matrix1);
            Console.WriteLine(matrixCopy.ToString());
            Console.ReadKey();

            try
            {
                Console.WriteLine("{0}-{1}", matrix1.GetNumberRows(), matrix1.GetNumberColumns());
                Console.ReadKey();
            }
            catch (IllegalArgumentException)
            {
                Console.WriteLine("Индекс должен быть равен 0 или 1");
                Console.ReadKey();
            }


            try
            {
                matrix1.Add(matrix2);
                Console.WriteLine(matrix1.ToString());
                Console.ReadKey();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("размерность матриц должна быть одинаковая");
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

            matrix1.Transposition();
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine(matrix1.GetColumn(2).ToString());
            Console.ReadKey();
        }
    }
}
