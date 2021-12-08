using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day8Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day8.Day8(true);
            Assert.AreEqual(26, d.Part1());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day8.Day8();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var testDisplay = new Day8.Display("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");
            Assert.AreEqual(5353, testDisplay.CalculateOutput());

            var d = new Day8.Day8(true);
            Assert.AreEqual(61229, d.Part2());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day8.Day8();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
