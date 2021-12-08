using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
    public class BoardHandler
    {
        private readonly Dictionary<int, List<BingoBoard>> _numberOccurrence;
        private readonly List<BingoBoard> _remainingBoards;

        public BoardHandler(string[] lines)
        {
            _remainingBoards = new List<BingoBoard>();
            _numberOccurrence = new Dictionary<int, List<BingoBoard>>();

            int i = 0;
            while (true)
            {
                string[] boardLines = lines
                    .Skip(6 * i)
                    .Take(5)
                    .ToArray();
                if (boardLines.Length != 5)
                    return;

                var b = new BingoBoard(boardLines);
                _remainingBoards.Add(b);
                foreach (var n in b.OriginalNumbers)
                {
                    if (!_numberOccurrence.ContainsKey(n))
                        _numberOccurrence[n] = new List<BingoBoard>();
                    _numberOccurrence[n].Add(b);
                }

                i++;
            }
        }

        public IEnumerable<int> Play(int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (_numberOccurrence.TryGetValue(number, out var boards))
                {
                    foreach (var b in boards)
                    {
                        if (b.IsBingo(number))
                        {
                            _remainingBoards.Remove(b);
                            yield return number * b.GetUnsuedNumbers().Sum();

                            if (_remainingBoards.Count == 0)
                                yield break;
                        }
                    }
                }
            }
        }
    }
}
