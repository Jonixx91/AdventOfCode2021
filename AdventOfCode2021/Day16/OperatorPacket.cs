using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day16
{
    public class OperatorPacket : Packet
    {
        private readonly int _typeId;

        public Packet[] Subpackets { get; }
        public override int TotalVersion => Version + Subpackets.Sum(p => p.TotalVersion);
        public override long Value
        {
            get
            {
                switch (_typeId)
                {
                    case 0:
                        return Subpackets.Sum(p => p.Value);
                    case 1:
                        long product = 1;
                        foreach (var p in Subpackets)
                            product *= p.Value;
                        return product;
                    case 2:
                        return Subpackets.Min(p => p.Value);
                    case 3:
                        return Subpackets.Max(p => p.Value);
                    case 5:
                        if (Subpackets[0].Value > Subpackets[1].Value)
                            return 1;
                        return 0;
                    case 6:
                        if (Subpackets[0].Value < Subpackets[1].Value)
                            return 1;
                        return 0;
                    case 7:
                        if (Subpackets[0].Value == Subpackets[1].Value)
                            return 1;
                        return 0;
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public OperatorPacket(int version, int typeId, Packet[] subPackets) 
            : base(version)
        {
            _typeId = typeId;
            Subpackets = subPackets;
        }
    }
}
