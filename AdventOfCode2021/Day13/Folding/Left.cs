namespace AdventOfCode2021.Day13.Folding
{
    class Left : FoldOperation
    {
        public Left(int line) 
            : base(line)
        {
        }

        public override void Fold(Point p)
        {
            p.Set(Fold(p.X), p.Y);
        }
    }
}
