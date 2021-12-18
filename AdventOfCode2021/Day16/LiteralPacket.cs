using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day16
{
    public class LiteralPacket : Packet
    {
        public override long Value { get; }

        private LiteralPacket(int version, long value)
            : base(version)
        {
            Value = value;
        }

        public static LiteralPacket TryParse(int version, ref string binary)
        {
            string value = string.Empty;
            int i = 0;
            while (true)
            {
                string group = new string(binary.Skip(6 + i * 5).Take(5).ToArray());
                value += group.Substring(1, 4);
                i++;
                if (group[0] == '0')
                    break;
            }

            binary = new string(binary.Skip(6 + i * 5).ToArray());
            return new LiteralPacket(version, Convert.ToInt64(value, 2));
        }
    }
}
