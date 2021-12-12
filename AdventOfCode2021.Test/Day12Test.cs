using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day12Test
    {
        private readonly string[] ex2 = new string[]
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc"
        };
        private readonly string[] ex3 = new string[]
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW"
        };

        [TestMethod]
        public void Part1Test()
        {
            var d = new Day12.Day12(true);
            Assert.AreEqual(10, d.Part1());
            Assert.AreEqual(19, d.Part1(ex2));
            Assert.AreEqual(226, d.Part1(ex3));
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day12.Day12();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day12.Day12(true);
            Assert.AreEqual(36, d.Part2());
            Assert.AreEqual(103, d.Part2(ex2));
            Assert.AreEqual(3509, d.Part2(ex3));
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day12.Day12();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
