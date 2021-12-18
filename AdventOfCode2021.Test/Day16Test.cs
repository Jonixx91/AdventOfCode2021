using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;

namespace AdventOfCode2021.Test
{
    [TestClass]
    public class Day16Test
    {
        [TestMethod]
        public void ParseLiteral()
        {
            var literal = Day16.Packet.Parse("D2FE28") as Day16.LiteralPacket;
            Assert.IsTrue(literal != null);
            Assert.AreEqual(literal.Value, 2021);
        }

        [TestMethod]
        public void ParseOperator()
        {
            var op1 = Day16.Packet.Parse("38006F45291200") as Day16.OperatorPacket;
            Assert.IsTrue(op1 != null);
            Assert.AreEqual(op1.Version, 1);
            Assert.AreEqual(((Day16.LiteralPacket)op1.Subpackets[0]).Value, 10);
            Assert.AreEqual(((Day16.LiteralPacket)op1.Subpackets[1]).Value, 20);

            var op2 = Day16.Packet.Parse("EE00D40C823060") as Day16.OperatorPacket;
            Assert.IsTrue(op2 != null);
            Assert.AreEqual(op2.Version, 7);
            Assert.AreEqual(((Day16.LiteralPacket)op2.Subpackets[0]).Value, 1);
            Assert.AreEqual(((Day16.LiteralPacket)op2.Subpackets[1]).Value, 2);
            Assert.AreEqual(((Day16.LiteralPacket)op2.Subpackets[2]).Value, 3);
        }

        [TestMethod]
        public void ParseNestedOperator()
        {
            Assert.AreEqual(Day16.Packet.Parse("8A004A801A8002F478").TotalVersion, 16);
            Assert.AreEqual(Day16.Packet.Parse("620080001611562C8802118E34").TotalVersion, 12);
            Assert.AreEqual(Day16.Packet.Parse("C0015000016115A2E0802F182340").TotalVersion, 23);
            Assert.AreEqual(Day16.Packet.Parse("A0016C880162017C3686B18A3D4780").TotalVersion, 31);
        }

        [TestMethod]
        public void Part1()
        {
            var d = new Day16.Day16();
            Clipboard.SetText(d.Part1().ToString());
        }

        [TestMethod]
        public void TestOperators()
        {
            Assert.AreEqual(Day16.Packet.Parse("C200B40A82").Value, 3);
            Assert.AreEqual(Day16.Packet.Parse("04005AC33890").Value, 54);
            Assert.AreEqual(Day16.Packet.Parse("880086C3E88112").Value, 7);
            Assert.AreEqual(Day16.Packet.Parse("CE00C43D881120").Value, 9);
            Assert.AreEqual(Day16.Packet.Parse("D8005AC2A8F0").Value, 1);
            Assert.AreEqual(Day16.Packet.Parse("F600BC2D8F").Value, 0);
            Assert.AreEqual(Day16.Packet.Parse("9C005AC2F8F0").Value, 0);
            Assert.AreEqual(Day16.Packet.Parse("9C0141080250320F1802104A08").Value, 1);
        }

        [TestMethod]
        public void Part2()
        {
            var d = new Day16.Day16();
            Clipboard.SetText(d.Part2().ToString());
        }
    }
}
