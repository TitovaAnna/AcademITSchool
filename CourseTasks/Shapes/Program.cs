using System;


namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape triangle = new Triangle(0, 0, 2, 1, 3, -3);
            triangle.Name = "Tреугольник1";

            Shape square = new Square(5);
            square.Name = "Квадрат1";

            Shape circle = new Circle(5);
            circle.Name = "Окружность1";

            Shape rectangle = new Rectangle(4, 3);
            rectangle.Name = "Прямоугольник2";

            Shape circle2 = new Circle(3);
            circle2.Name = "Окружность2";

            Shape rectangle2 = new Rectangle(5, 7);
            rectangle2.Name = "Треугольник2";

            Console.WriteLine("Максимальная площадь у фигуры {0}", GetShapeAreaMax(triangle, square, circle).Name);
            Console.ReadKey();

            Shape shapePerimeterMax = GetShapePerimeterSecond(triangle, square, circle, circle2, rectangle2);
            if (shapePerimeterMax == null)
            {
                Console.WriteLine("Задано меньше двух фигур");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Второй по величине периметр у фигуры {0}", shapePerimeterMax.Name);
            Console.ReadKey();
        }

        public static Shape GetShapeAreaMax(params Shape[] shapes)
        {
            PrintAreaAndPerimeter(shapes);
            Shape shapeAreaMax = shapes[0];
            for (int i = 1; i < shapes.Length; i++)
            {
                if (shapes[i].getArea() > shapeAreaMax.getArea())
                {
                    shapeAreaMax = shapes[i];
                }
            }
            return shapeAreaMax;
        }

        public static Shape GetShapePerimeterSecond(params Shape[] shapes)
        {
            PrintAreaAndPerimeter(shapes);
            if (shapes.Length < 2)
            {
                return null;
            }
            for (int i = 1; i < shapes.Length; i++)
            {
                Shape temp = shapes[i];
                int j = i - 1;
                while ((j >= 0) && (shapes[j].getPerimeter() < temp.getPerimeter()))
                {
                    shapes[j + 1] = shapes[j];
                    j--;
                }
                shapes[j + 1] = temp;
            }
            return shapes[1];
        }

        public static void PrintAreaAndPerimeter(params Shape[] shapes)
        {
            Console.WriteLine();
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("{0}:S={1},P={2}", shapes[i].Name, Math.Round(shapes[i].getArea(), 3), Math.Round(shapes[i].getPerimeter(), 3));
            }
        }
    }
}
