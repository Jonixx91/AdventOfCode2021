using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public abstract class Day
    {
        public List<string> Input { get; }

        protected Day(bool isTest = false)
        {
            string dir = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                GetType().Name);
            string file = System.IO.Path.Combine(
                dir,
                isTest ? "test.txt" : "input.txt");
            Input = System.IO.File.ReadAllLines(file).ToList();
        }
    }
}
