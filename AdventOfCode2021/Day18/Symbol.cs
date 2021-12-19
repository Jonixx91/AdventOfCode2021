using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day18
{
    public abstract class Symbol
    {
        public Pair Parent { get; private set; }
        public int Level { get; private set; }

        protected Symbol(int level, Pair parent)
        {
            Level = level;
            Parent = parent;
        }

        public virtual void Initialize(int level, Pair parent)
        {
            Level = level;
            Parent = parent;
        }

        public abstract long Magnitude();

        public abstract void FetchAll(ref List<Symbol> symbols);

        public bool Reduce()
        {
            var allSymbols = new List<Symbol>();
            FetchAll(ref allSymbols);

            var toExplode = allSymbols.OfType<Pair>().FirstOrDefault(p => p.NeedToExplode());
            if (toExplode != null)
            {
                toExplode.Explode(allSymbols);
                return true;
            }

            var toSplit = allSymbols.OfType<Number>().FirstOrDefault(n => n.NeedToSplit());
            if (toSplit != null)
            {
                toSplit.Split();
                return true;
            }

            return false;
        }

        public static Pair Parse(string s)
        {
            int level = 0;
            Symbol current = null;
            foreach (var c in s)
            {
                switch (c)
                {
                    case '[':
                        current = new Pair(level++, current as Pair);
                        break;
                    case ']':
                        current.Parent.Right = current;
                        if (current.Parent != null)
                            current = current.Parent;
                        level--;
                        break;
                    case ',':
                        current.Parent.Left = current;
                        current = current.Parent;
                        break;
                    default:
                        current = new Number(level, current as Pair, int.Parse(new string(new char[] { c })));
                        break;
                }
            }

            return (Pair)current;
        }
    }
}
