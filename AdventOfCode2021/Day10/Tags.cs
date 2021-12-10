using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day10
{
    public static class Tags
    {
        public static readonly Dictionary<char, char> ChunkTags = new Dictionary<char, char>()
        {
            ['('] = ')',
            ['{'] = '}',
            ['['] = ']',
            ['<'] = '>'
        };
    }
}
