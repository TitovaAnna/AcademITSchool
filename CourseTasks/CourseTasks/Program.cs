using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(new double[] { 2, 4 });
            Vector vector2 = new Vector(new double[] { 3, 4, 1, 6, 6 });
            try
            {
                Vector vector3 = new Vector(-3);
            }
            catch (IllegalArgumentException)
            {
                Console.WriteLine("Задана отрицательная размерность");
                Console.ReadKey();
            }

            Console.WriteLine(vector1.ToString());
            Console.WriteLine(vector2.ToString());
            Console.ReadKey();

            vector2.AddVector(vector1);
            Console.WriteLine(vector2.ToString());
            Console.ReadKey();

            vector2.SubtractVector(vector1);
            Console.WriteLine(vector2.ToString());
            Console.ReadKey();

            Console.WriteLine(vector2.GetLength());
            Console.ReadKey();

            Console.WriteLine(Vector.GetVectorSum(vector1, vector2).ToString());
            Console.ReadKey();

            Console.WriteLine(Vector.GetScalarMultiplication(vector1, vector2).ToString());
            Console.ReadKey();
            
            }
        }
    }
