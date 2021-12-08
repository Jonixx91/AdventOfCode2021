using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day8
{
    public class Display
    {
        public string[] Input { get; }
        public string[] Output { get; }

        public Display(string line)
        {
            string[] parts = line.Split('|')
                .Select(s => s.Trim())
                .ToArray();
            Input = parts[0].Split(' ');
            Output = parts[1].Split(' ');
        }

        private static Dictionary<string, int> _numbers = new Dictionary<string, int>()
        {
            ["abcefg"] = 0,
            ["cf"] = 1,
            ["acdeg"] = 2,
            ["acdfg"] = 3,
            ["bcdf"] = 4,
            ["abdfg"] = 5,
            ["abdefg"] = 6,
            ["acf"] = 7,
            ["abcdefg"] = 8,
            ["abcdfg"] = 9
        };

        public int CalculateOutput()
        {
            var byLength = new Dictionary<int, char[][]>();
            foreach (var g in Input.GroupBy(s => s.Length))
                byLength[g.Key] = g.Select(s => s.ToCharArray()).ToArray();

            var decoded = new Dictionary<int, char[]>
            {
                [1] = byLength[2].First(),
                [4] = byLength[4].First(),
                [7] = byLength[3].First(),
                [8] = byLength[7].First()
            };

            var segment = new Dictionary<char, char>(); // reality - wrong
            segment['a'] = decoded[7].Except(decoded[1]).FirstOrDefault();
            char[] bd = decoded[4].Except(decoded[1]).ToArray();
            char[] cf = decoded[1];
            var seg0Or6Or9 = byLength[6].ToList();
            decoded[6] = seg0Or6Or9.First(s => s.Intersect(cf).Count() == 1);
            seg0Or6Or9.Remove(decoded[6]);
            decoded[9] = seg0Or6Or9.First(s => s.Intersect(bd).Count() == 2);
            seg0Or6Or9.Remove(decoded[9]);
            decoded[0] = seg0Or6Or9.First();
            segment['d'] = decoded[8].Except(decoded[0]).First();
            segment['b'] = bd.Except(new[] { segment['d'] }).First();
            segment['e'] = decoded[8].Except(decoded[9]).First();
            var seg2Or3Or5 = byLength[5].ToList();
            decoded[3] = seg2Or3Or5.First(s => s.Intersect(cf).Count() == 2);
            seg2Or3Or5.Remove(decoded[3]);
            decoded[5] = seg2Or3Or5.First(s => s.Intersect(new[] { segment['b'] }).Count() == 1);
            seg2Or3Or5.Remove(decoded[5]);
            decoded[2] = seg2Or3Or5.First();
            segment['c'] = decoded[0].Except(decoded[6]).First();
            segment['f'] = cf.Except(new[] { segment['c'] }).First();
            segment['g'] = decoded[5].Except(decoded[4]).Except(new char[] { segment['a'] }).First();

            var invert = new Dictionary<char, char>();
            foreach (var kv in segment)
                invert[kv.Value] = kv.Key;
            
            string outputDecoded = "";
            foreach (var output in Output)
            {
                var decodedSegments = new List<char>();
                foreach (var c in output.ToCharArray())
                    decodedSegments.Add(invert[c]);
                decodedSegments.Sort();
                outputDecoded += _numbers[new string(decodedSegments.ToArray())];
            }

            return int.Parse(outputDecoded);
        }
    }
}
