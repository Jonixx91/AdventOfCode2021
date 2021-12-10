using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day10
{
    public class Chunk
    {
        public Chunk Parent { get; }
        public List<Chunk> Children { get; }
        public char ClosingTag { get; }

        public Chunk(Chunk parent, char closingTag)
        {
            Parent = parent;
            ClosingTag = closingTag;
            Children = new List<Chunk>();
        }

        public bool CanHandle(char c)
        {
            if (Tags.ChunkTags.ContainsKey(c))
                return true;

            if (c.Equals(ClosingTag))
                return true;

            return false;
        }

        public Chunk Handle(char c)
        {
            if (Tags.ChunkTags.ContainsKey(c))
            {
                var newChunk = new Chunk(this, Tags.ChunkTags[c]);
                Children.Add(newChunk);
                return newChunk;
            }

            if (c.Equals(ClosingTag))
                return Close();

            throw new ArgumentOutOfRangeException();
        }

        public Chunk Close()
        {
            Parent?.Children.Remove(this);
            return Parent;
        }
    }
}
