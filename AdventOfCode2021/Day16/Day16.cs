using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day16
{
    public class Day16 : Day
    {
        public Day16(bool isTest = false) 
            : base(isTest)
        {
        }

        public int Part1() => Packet.Parse(Input[0]).TotalVersion;
        public long Part2() => Packet.Parse(Input[0]).Value;
    }
}
