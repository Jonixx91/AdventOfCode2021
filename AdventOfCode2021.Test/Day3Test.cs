using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day3Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day3.Day3(true);
            Assert.AreEqual(198, d.CalculatePowerConsumption());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day3.Day3();
            Clipboard.SetText(d.CalculatePowerConsumption().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day3.Day3(true);
            Assert.AreEqual(230, d.CalculateLifeSupportRating());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day3.Day3();
            Clipboard.SetText(d.CalculateLifeSupportRating().ToString());
        }
    }
}
