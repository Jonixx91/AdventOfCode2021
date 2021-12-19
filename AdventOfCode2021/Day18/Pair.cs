using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day18
{
    public class Pair : Symbol
    {
        public Symbol Left { get; set; }
        public Symbol Right { get; set; }

        public Pair(int level, Pair parent) 
            : base(level, parent)
        {
        }

        public override void FetchAll(ref List<Symbol> symbols)
        {
            symbols.Add(this);
            Left.FetchAll(ref symbols);
            Right.FetchAll(ref symbols);
        }

        public override void Initialize(int level, Pair parent)
        {
            base.Initialize(level, parent);
            Left.Initialize(level + 1, this);
            Right.Initialize(level + 1, this);
        }

        public override long Magnitude() => 3 * Left.Magnitude() + 2 * Right.Magnitude();

        public bool NeedToExplode() => Level == 4 && Left is Number && Right is Number;
        public void Explode(List<Symbol> allSymbols)
        {
            int indexLeft = allSymbols.IndexOf(Left);
            var nextLeft = allSymbols.Take(indexLeft).Reverse().OfType<Number>().FirstOrDefault();
            nextLeft?.Add((Number)Left);

            int indexRight = allSymbols.IndexOf(Right);
            var nextRight = allSymbols.Skip(indexRight + 1).OfType<Number>().FirstOrDefault();
            nextRight?.Add((Number)Right);

            Parent.Replace(this, new Number(Level, Parent, 0));
        }

        public void Replace(Symbol oldSymbol, Symbol newSymbol)
        {
            if (Left == oldSymbol)
                Left = newSymbol;
            else
                Right = newSymbol;
        }

        public static Pair Add(Pair left, Pair right)
        {
            var newPair = new Pair(0, null)
            {
                Left = left,
                Right = right
            };
            left.Initialize(1, newPair);
            right.Initialize(1, newPair);
            return newPair;
        }

        public override string ToString() => $"[{Left},{Right}]";
    }
}
