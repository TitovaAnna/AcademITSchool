using System;


namespace Range
{
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

        public bool IsInside(double number)
        {
            return (number <= to) && (number >= from);
        }

        public Range GetCrossing(Range range)
        {
            if ((From >= range.To) || (range.From >= To))
            {
                return null;
            }
            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetCombination(Range range)
        {
            if ((From > range.To) || (range.From > To))
            {
                Range range1 = new Range(From, To);
                Range range2 = new Range(range.From, range.To);
                Range[] newRangeArrayNull = { range1, range2 };
                return newRangeArrayNull;
            }

            Range newRange = new Range(Math.Min(From, range.From), Math.Max(To, range.To));
            Range[] newRangeArray = { newRange };

            return newRangeArray;
        }

        public Range[] GetDifference(Range range)
        {
            if ((From >= range.To) || (range.From >= To))
            {
                Range range1 = new Range(From, To);
                Range[] newRangeArraySingle = { range1 };
                return newRangeArraySingle;
            }
            else if ((To > range.To) && (From < range.From))
            {
                Range[] newRangeArrayCouple = { new Range(From, range.From), new Range(range.To, To) };
                return newRangeArrayCouple;
            }
            else if ((To < range.To) && (From > range.From))
            {
                Range[] newRangeArrayNull = { };
                return newRangeArrayNull;
            }

            Range[] newRangeArray = { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
            return newRangeArray;
        }

    }
}
