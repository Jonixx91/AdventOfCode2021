using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day18Test
    {
        [TestMethod]
        public void ParseTest()
        {
            var d = new Day18.Day18(true);
            foreach (var l in d.Input)
                Assert.AreEqual(l, Day18.Symbol.Parse(l).ToString());
        }

        [TestMethod]
        public void TestOperations()
        {
            var pair1 = Day18.Symbol.Parse("[[[[4,3],4],4],[7,[[8,4],9]]]");
            var pair2 = Day18.Symbol.Parse("[1,1]");
            var add = Day18.Pair.Add(pair1, pair2);
            Assert.AreEqual(add.ToString(), "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]");

            //Explode
            Assert.IsTrue(add.Reduce());
            Assert.AreEqual(add.ToString(), "[[[[0,7],4],[7,[[8,4],9]]],[1,1]]");

            //Explode
            Assert.IsTrue(add.Reduce());
            Assert.AreEqual(add.ToString(), "[[[[0,7],4],[15,[0,13]]],[1,1]]");

            //Split
            Assert.IsTrue(add.Reduce());
            Assert.AreEqual(add.ToString(), "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]");

            //Split
            Assert.IsTrue(add.Reduce());
            Assert.AreEqual(add.ToString(), "[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]");

            //Explode
            Assert.IsTrue(add.Reduce());
            Assert.AreEqual(add.ToString(), "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]");

            Assert.IsFalse(add.Reduce());
        }

        [TestMethod]
        public void CalculateMagnitude()
        {
            Assert.AreEqual(Day18.Symbol.Parse("[[1,2],[[3,4],5]]").Magnitude(), 143);
            Assert.AreEqual(Day18.Symbol.Parse("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]").Magnitude(), 1384);
            Assert.AreEqual(Day18.Symbol.Parse("[[[[1,1],[2,2]],[3,3]],[4,4]]").Magnitude(), 445);
            Assert.AreEqual(Day18.Symbol.Parse("[[[[3,0],[5,3]],[4,4]],[5,5]]").Magnitude(), 791);
            Assert.AreEqual(Day18.Symbol.Parse("[[[[5,0],[7,4]],[5,5]],[6,6]]").Magnitude(), 1137);
            Assert.AreEqual(Day18.Symbol.Parse("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]").Magnitude(), 3488);
        }

        [TestMethod]
        public void Part1Test()
        {
            var d = new Day18.Day18(true);
            Assert.AreEqual(4140, d.Part1());
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day18.Day18();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void Part2Test()
        {
            var d = new Day18.Day18(true);
            Assert.AreEqual(3993, d.Part2());
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day18.Day18();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
