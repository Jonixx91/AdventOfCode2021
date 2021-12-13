using System.Linq;

namespace AdventOfCode2021.Day13.Folding
{
    abstract class FoldOperation
    {
        public int Line { get; }

        protected FoldOperation(int line)
        {
            Line = line;
        }

        protected int Fold(int i)
        {
            if (i < Line)
                return i;

            return Line - (i - Line);
        }

        public abstract void Fold(Point p);

        public static FoldOperation Create(string s)
        {
            var shortened = s.Replace("fold along ", "");
            var parts = shortened.Split('=');
            var line = int.Parse(parts.Last());
            if (parts.First().Equals("x"))
                return new Left(line);
            return new Up(line);
        }
    }
}
