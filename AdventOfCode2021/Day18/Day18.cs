using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day18
{
    public class Day18 : Day
    {
        public Day18(bool isTest = false) 
            : base(isTest)
        {
        }

        public long Part1()
        {
            var symbols = Input.Select(s => Symbol.Parse(s)).ToArray();
            var current = symbols.First();
            foreach (var s in symbols.Skip(1))
            {
                current = Pair.Add(current, s);
                while (true)
                {
                    if (!current.Reduce())
                        break;
                }
            }

            return current.Magnitude();
        }

        public long Part2()
        {
            var symbols = Input.Select(s => Symbol.Parse(s)).ToArray();
            var results = new List<(int N1, int N2, long Result)>();
            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = 0; j < Input.Count; j++)
                {
                    if (i == j)
                        continue;

                    var add = Pair.Add(Symbol.Parse(Input[i]), Symbol.Parse(Input[j]));
                    while (true)
                    {
                        if (!add.Reduce())
                            break;
                    }
                    results.Add((i, j, add.Magnitude()));
                }
            }

            return results.Select(t => t.Result).Max();
        }
    }
}
