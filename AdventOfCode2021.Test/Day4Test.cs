using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day4Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day4.Day4(true);
            Assert.AreEqual(4512, d.GetFirstWinningBoard());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day4.Day4();
            Clipboard.SetText(d.GetFirstWinningBoard().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day4.Day4(true);
            Assert.AreEqual(1924, d.GetLastWinningBoard());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day4.Day4();
            Clipboard.SetText(d.GetLastWinningBoard().ToString());
        }
    }
}
