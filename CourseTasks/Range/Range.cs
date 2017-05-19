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
            else
            {
                double rangeNewFrom = (From > range.From) ? From : range.From;
                double rangeNewTo = (To < range.To) ? To : range.To;
                return new Range(rangeNewFrom, rangeNewTo);
            }
        }

        public Range[] GetCombination(Range range)
        {
            if ((From > range.To) || (range.From > To))
            {
                Range range1 = this;
                Range range2 = range;
                Range[] newRangeArrayNull = { range1, range2 };
                return newRangeArrayNull;
            }

            double min = Math.Min(From, range.From);
            double max = Math.Max(To, range.To);

            Range newRange = new Range(min, max);
            Range[] newRangeArray = { newRange };

            return newRangeArray;

        }

        public Range[] GetDifference(Range range)
        {

            if ((From >= range.To) || (range.From >= To))
            {
                Range range1 = this;
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

            double min = Math.Min(From, range.From);
            double max = Math.Max(To, range.To);

            Range[] newRangeArray = { new Range(min, max) };
            return newRangeArray;
        }

    }
}
