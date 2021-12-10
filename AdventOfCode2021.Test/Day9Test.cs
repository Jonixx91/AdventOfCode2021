﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day9Test
    {
        [TestMethod]
        public void Part1Test()
        {
            var d = new Day9.Day9(true);
            Assert.AreEqual(15, d.Part1());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day9.Day9();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day9.Day9(true);
            Assert.AreEqual(1134, d.Part2());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day9.Day9();
            Clipboard.SetText(d.Part2().ToString()); // 1342440 incorrect, 1224300 :/
        }
    }
}
