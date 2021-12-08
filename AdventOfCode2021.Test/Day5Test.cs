using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day5Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day5.Day5(true);
            Assert.AreEqual(5, d.Part1());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day5.Day5();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day5.Day5(true);
            Assert.AreEqual(12, d.Part2());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day5.Day5();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
