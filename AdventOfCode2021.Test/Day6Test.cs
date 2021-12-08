using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day6Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day6.Day6(true);
            var simulations = d.Simulate2(18, 80).ToArray();
            Assert.AreEqual(26, simulations[0]);
            Assert.AreEqual(5934, simulations[1]);
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day6.Day6();
            Clipboard.SetText(d.Simulate(80).FirstOrDefault().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day6.Day6(true);
            Assert.AreEqual(26984457539, d.Simulate2(256).FirstOrDefault());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day6.Day6();
            Clipboard.SetText(d.Simulate2(256).FirstOrDefault().ToString());
        }
    }
}
