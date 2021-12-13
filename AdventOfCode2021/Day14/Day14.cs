using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day13.Folding;

namespace AdventOfCode2021.Day14
{
    public class Day14 : Day
    {
        private readonly Dictionary<string, char> _rules;

        public string Template { get; }

        public Day14(bool isTest = false) 
            : base(isTest)
        {
            Template = Input.First();
            _rules = new Dictionary<string, char>();
            foreach (var l in Input.Skip(2))
            {
                var parts = Regex.Split(l, " -> ");
                _rules.Add(parts.First(), parts.Last()[0]);
            }
        }

        public Dictionary<string, long> CreateTemplateSequence()
        {
            var seq = new Dictionary<string, long>();
            var i = 0;
            while (true)
            {
                var current = Template.Skip(i).Take(2).ToArray();
                if (current.Length < 2)
                    return seq;

                var tuple = new string(current);
                if (!seq.ContainsKey(tuple))
                    seq.Add(tuple, 0);
                seq[tuple]++;
                i++;
            }
        }

        public Dictionary<string, long> RunStep(Dictionary<string, long> sequence)
        {
            var newSeq = new Dictionary<string, long>();
            foreach (var kv in sequence)
            {
                if (_rules.TryGetValue(kv.Key, out char insert))
                {
                    var newTuples = new[]
                    {
                        new string(new[] { kv.Key[0], insert }),
                        new string(new[] { insert, kv.Key[1] })
                    };

                    foreach (var t in newTuples)
                    {
                        if (!newSeq.ContainsKey(t))
                            newSeq.Add(t, 0);
                        newSeq[t] += kv.Value;
                    }
                }
            }

            return newSeq;
        }

        private long SubtractMostAndLeastCommon(int step)
        {
            var current = CreateTemplateSequence();
            for (int i = 0; i < step; i++)
                current = RunStep(current);

            var occurrence = new Dictionary<char, long>();
            foreach (var kv in current)
            {
                foreach (var c in kv.Key)
                {
                    if (!occurrence.ContainsKey(c))
                        occurrence[c] = 0;
                    occurrence[c] += kv.Value;
                }
            }

            foreach (var k in occurrence.Keys.ToArray())
            {
                if (occurrence[k] % 2 == 1)
                    occurrence[k]++;
            }

            foreach (var k in occurrence.Keys.ToArray())
                occurrence[k] /= 2;

            var sorted = occurrence
                .OrderBy(kv => kv.Value)
                .ToArray();
            return sorted.Last().Value - sorted.First().Value;
        }

        public long Part1() => SubtractMostAndLeastCommon(10);

        public long Part2() => SubtractMostAndLeastCommon(40);
    }
}
