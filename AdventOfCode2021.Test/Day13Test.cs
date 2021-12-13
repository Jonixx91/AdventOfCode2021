using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day13Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day13.Day13(true);
            Assert.AreEqual(17, d.Part1());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day13.Day13();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day13.Day13(true);
            Assert.AreEqual(36, d.Part2());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day13.Day13();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
