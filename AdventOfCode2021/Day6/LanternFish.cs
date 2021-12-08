using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day6
{
    class LanternFish
    {
        private int _timer;

        public LanternFish(int timer)
        {
            _timer = timer;
        }

        public void SimulateOneDay(ref List<LanternFish> allFishes)
        {
            switch (_timer)
            {
                case 0:
                    _timer = 6;
                    allFishes.Add(new LanternFish(8));
                    break;
                default:
                    _timer--;
                    break;
            }
        }

        public override string ToString() => _timer.ToString();
    }
}
