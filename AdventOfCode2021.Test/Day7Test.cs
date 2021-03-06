using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day7Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day7.Day7(true);
            Assert.AreEqual(37, d.Part1());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day7.Day7();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day7.Day7(true);
            Assert.AreEqual(206, d.CalculateAlignmentToFactorial(2));
            Assert.AreEqual(168, d.Part2());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day7.Day7();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
