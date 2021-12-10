using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day10
{
    public class Day10 : Day
    {
        public Day10(bool isTest = false) 
            : base(isTest)
        {
        }

        private int GetFail(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
            }

            throw new ArgumentOutOfRangeException();
        }

        public int Part1()
        {
            int fails = 0;
            foreach (var l in Input)
            {
                Chunk currentChunk = null;
                foreach (var c in l.ToCharArray())
                {
                    if (currentChunk == null)
                    {
                        currentChunk = new Chunk(null, Tags.ChunkTags[c]);
                    }
                    else
                    {
                        if (currentChunk.CanHandle(c))
                        {
                            currentChunk = currentChunk.Handle(c);
                        }
                        else
                        {
                            fails += GetFail(c);
                            break;
                        }
                    }
                }
            }
            
            return fails;
        }

        private int GetScore(char c)
        {
            switch (c)
            {
                case ')':
                    return 1;
                case ']':
                    return 2;
                case '}':
                    return 3;
                case '>':
                    return 4;
            }

            throw new ArgumentOutOfRangeException();
        }
        
        public long Part2()
        {
            var scores = new List<long>();
            foreach (var l in Input)
            {
                long score = 0;
                bool isIncorrect = false;
                Chunk currentChunk = null;
                foreach (var c in l.ToCharArray())
                {
                    if (currentChunk == null)
                    {
                        currentChunk = new Chunk(null, Tags.ChunkTags[c]);
                    }
                    else
                    {
                        if (currentChunk.CanHandle(c))
                        {
                            currentChunk = currentChunk.Handle(c);
                        }
                        else
                        {
                            isIncorrect = true;
                            break;
                        }
                    }
                }

                if (isIncorrect)
                    continue;
                
                while (currentChunk != null)
                {
                    score *= 5;
                    score += GetScore(currentChunk.ClosingTag);
                    currentChunk = currentChunk.Close();
                }
                
                scores.Add(score);
            }

            scores = scores.OrderBy(s => s).ToList();
            return scores[scores.Count / 2];
        }
    }
}
