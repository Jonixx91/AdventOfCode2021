using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day18
{
    public class Number : Symbol
    {
        public int Value { get; set; }

        public Number(int level, Pair parent, int value) 
            : base(level, parent)
        {
            Value = value;
        }

        public void Add(Number n)
        {
            Value += n.Value;
        }

        public override void FetchAll(ref List<Symbol> symbols)
        {
            symbols.Add(this);
        }

        public override long Magnitude() => Value;

        public bool NeedToSplit() => Value >= 10;
        public void Split()
        {
            var newPair = new Pair(Level, Parent);
            newPair.Left = new Number(Level + 1, newPair, Convert.ToInt32(Math.Floor(Value / (double)2)));
            newPair.Right = new Number(Level + 1, newPair, Convert.ToInt32(Math.Ceiling(Value / (double)2)));
            Parent.Replace(this, newPair);
        }

        public override string ToString() => Value.ToString();
    }
}
