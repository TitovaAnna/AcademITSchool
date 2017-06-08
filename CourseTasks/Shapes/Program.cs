using System;


namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape triangle = new Triangle(0, 0, 2, 1, 3, -3);
            IShape square = new Square(5);
            IShape square3 = new Square(4);
            IShape square2 = new Square(3);
            IShape square1 = new Square(2);
            IShape circle = new Circle(5);
            IShape rectangle = new Rectangle(4, 3);
            IShape circle2 = new Circle(3);
            IShape rectangle2 = new Rectangle(5, 7);
            IShape rectangle3 = new Rectangle(5, 7);

            Console.WriteLine("Максимальная площадь у фигуры {0}", GetShapeAreaMax(triangle, square, circle).ToString());
            Console.ReadKey();

            IShape shapePerimeterMax = GetShapePerimeterSecond(square1, square2, square3, square);
            if (shapePerimeterMax == null)
            {
                Console.WriteLine("Задано меньше двух фигур");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Второй по величине периметр у фигуры {0}", shapePerimeterMax.ToString());
            Console.ReadKey();

            Console.WriteLine("Hash1={0};Hash2 ={1};Equals={2}", rectangle2.GetHashCode(), rectangle3.GetHashCode(), rectangle3.Equals(rectangle2));
            Console.ReadKey();
        }

        public static IShape GetShapeAreaMax(params IShape[] shapes)
        {
            IShape shapeAreaMax = shapes[0];
            for (int i = 1; i < shapes.Length; i++)
            {
                if (shapes[i].GetArea() > shapeAreaMax.GetArea())
                {
                    shapeAreaMax = shapes[i];
                }
            }
            return shapeAreaMax;
        }

        public static IShape GetShapePerimeterSecond(params IShape[] shapes)
        {
            if (shapes.Length < 2)
            {
                return null;
            }
            Array.Sort(shapes, new PerimeterComparer());
            return shapes[1];
        }
    }
}
