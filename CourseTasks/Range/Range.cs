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
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }
            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if ((From >= range.To) || (range.From >= To))
            {
                return new Range[] { new Range(From, To) };
            }
            else if ((To > range.To) && (From < range.From))
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }
            else if ((To <= range.To) && (From >= range.From))
            {
                return new Range[] { };
            }
            else if (From < range.From)
            {
                return new Range[] { new Range(From, range.From) };
            }
            return new Range[] { new Range(range.To, To) };
        }
    }
}
