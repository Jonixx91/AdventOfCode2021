using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day8
{
    public class Signal
    {
        public string[] Input { get; }
        public string[] Output { get; }

        public Signal(UniqueSignals unique, string line)
        {
            string[] parts = line.Split('|')
                .Select(s => s.Trim())
                .ToArray();
            Input = Read(parts[0]);
            Output = Read(parts[1]);
            foreach (var o in Output)
                if (!unique.Contains(o))
                    unique.Add(o);
        }

        private string[] Read(string part)
        {
            var signals = part.Split(' ');
            for (int i = 0; i < signals.Length; i++)
                signals[i] = new string(signals[i].ToCharArray().OrderBy(c => c).ToArray());
            return signals;

        }
    }
}
