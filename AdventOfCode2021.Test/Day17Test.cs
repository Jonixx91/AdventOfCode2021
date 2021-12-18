using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day17Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day17.Day17();
            Assert.AreEqual(45, d.FindMaxY(d.TestTarget));
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day17.Day17();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day17.Day17();
            Assert.AreEqual(112, d.FindCombinations(d.TestTarget));
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day17.Day17();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
