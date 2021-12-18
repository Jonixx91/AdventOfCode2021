using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day16
{
    public abstract class Packet
    {
        public int Version { get; }
        public virtual int TotalVersion => Version;
        public abstract long Value { get; }

        protected Packet(int version)
        {
            Version = version;
        }

        private static int Read(string binary, int skip) => Convert.ToInt32(new string(binary.Skip(skip * 3).Take(3).ToArray()), 2);
        public static int ReadVersion(string binary) => Read(binary, 0);
        public static int ReadTypedId(string binary) => Read(binary, 1);

        public static Packet Parse(string hex)
        {
            string binary = string.Join(
                string.Empty,
                hex.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            return Parse(ref binary);
        }

        public static Packet Parse(ref string binary)
        {
            int version = ReadVersion(binary);
            int typeId = ReadTypedId(binary);
            if (typeId == 4)
                return LiteralPacket.TryParse(version, ref binary);

            var subPackets = new List<Packet>();
            char lengthTypeId = binary[6];
            switch (lengthTypeId)
            {
                case '0':
                    {
                        int totalLength = Convert.ToInt32(new string(binary.Skip(7).Take(15).ToArray()), 2);
                        int processed = 0;
                        binary = new string(binary.Skip(22).ToArray());
                        while (processed < totalLength)
                        {
                            int preProcessLength = binary.Length;
                            subPackets.Add(Parse(ref binary));
                            processed += preProcessLength - binary.Length;
                        }
                        break;
                    }
                case '1':
                    {
                        int subPacketsCount = Convert.ToInt32(new string(binary.Skip(7).Take(11).ToArray()), 2);
                        binary = new string(binary.Skip(18).ToArray());
                        for (int i = 0; i < subPacketsCount; i++)
                            subPackets.Add(Parse(ref binary));
                        break;
                    }
            }

            return new OperatorPacket(version, typeId, subPackets.ToArray());
        }
    }
}
