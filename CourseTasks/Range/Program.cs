using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(40, 75);
            Range range2 = new Range(40, 70);

            Range newRange = range1.GetCrossing(range2);

            if (newRange == null)
            {
                Console.WriteLine("Нет пересечения диапазонов");
            }
            else
            {
                Console.WriteLine("Пересечение диапазонов {0}-{1}", newRange.From, newRange.To);
            }

            Range[] rangeCombination = range1.GetCombination(range2);
            PrintRangeArray(rangeCombination);

            Range[] rangeDifference = range1.GetDifference(range2);
            if (rangeDifference.Length == 0)
            {
                Console.WriteLine("Нет решения");
            }
            else
            {
                PrintRangeArray(rangeDifference);
            }
            Console.ReadKey();
        }

        public static void PrintRangeArray(Range[] rangeArray)
        {
            if (rangeArray.Length == 2)
            {
                Console.WriteLine("{0}-{1},{2}-{3} ", rangeArray[0].From, rangeArray[0].To,
                rangeArray[1].From, rangeArray[1].To);
            }
            else if (rangeArray.Length == 1)
            {
                Console.WriteLine("{0}-{1}", rangeArray[0].From, rangeArray[0].To);
            }
        }
    }
}
