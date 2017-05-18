using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(20, 34);
            Range range2 = new Range(19, 37);

            Range newRange = GetCrossing(range1, range2);

            if (newRange == null)
            {
                Console.WriteLine("Нет пересечения диапазонов");
            }
            else
            {
                Console.WriteLine("Пересечение диапазонов {0}-{1}", newRange.From, newRange.To);
            }

            Range[] rangeCombination = GetCombination(range1, range2);
            PrindRangeArray(rangeCombination);

            Range[] rangeDifference = GetDifference(range1, range2);

            if (rangeDifference == null)
            {
                Console.WriteLine("Нет решения");
            }
            else
            {
                PrindRangeArray(rangeDifference);
            }
            Console.ReadKey();
        }

        public static void PrindRangeArray(Range[] rangeArray)
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

        public static Range GetCrossing(Range range1, Range range2)
        {

            if ((range1.From > range2.To) || (range2.From > range1.To))
            {
                return null;
            }
            else
            {
                double rangeNewFrom = (range1.From > range2.From) ? range1.From : range2.From;
                double rangeNewTo = (range1.To < range2.To) ? range1.To : range2.To;
                return new Range(rangeNewFrom, rangeNewTo);
            }
        }

        public static Range[] GetCombination(Range range1, Range range2)
        {

            if ((range1.From > range2.To) || (range2.From > range1.To))
            {
                Range[] newRangeArray = { range1, range2 };
                return newRangeArray;
            }
            else
            {
                double min = (range1.From < range2.From) ? range1.From : range2.From;
                double max = (range1.To > range2.To) ? range1.To : range2.To;
                Range newRange = new Range(min, max);
                Range[] newRangeArray = { newRange };
                return newRangeArray;
            }
        }

        public static Range[] GetDifference(Range range1, Range range2)
        {

            if ((range1.From > range2.To) || (range2.From > range1.To))
            {
                Range[] newRangeArray = { range1 };
                return newRangeArray;
            }
            else if ((range1.To > range2.To) && (range1.From < range2.From))
            {
                Range[] newRangeArray = { new Range(range1.From, range2.From), new Range(range2.To, range1.To) };
                return newRangeArray;
            }
            else if ((range1.To < range2.To) && (range1.From > range2.From))
            {
                return null;
            }
            else
            {
                double min = (range1.From < range2.From) ? range1.From : range2.From;
                double max = (range1.To > range2.To) ? range2.To : range1.To;
                Range[] newRangeArray = { new Range(min, max) };
                return newRangeArray;
            }
        }
    }

    class Range
    {
        private double from;
        private double to;

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }
        public double Length
        {
            get { return to - from; }
        }
        public double From
        {
            get { return from; }
            set { from = value; }
        }
        public double To
        {
            get { return to; }
            set { to = value; }
        }
    }

}
