namespace AdventOfCode2021.Day13.Folding
{
    class Up : FoldOperation
    {
        public Up(int line) 
            : base(line)
        {
        }

        public override void Fold(Point p)
        {
            p.Set(p.X, Fold(p.Y));
        }
    }
}
