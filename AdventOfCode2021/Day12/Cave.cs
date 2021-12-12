using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day12
{
    public class Cave
    {
        public List<Cave> Connections { get; }
        public string Name { get; }
        public bool IsStart { get; }
        public bool IsEnd { get; }
        public bool IsSmall { get; }

        public Cave(string name)
        {
            Connections = new List<Cave>();
            IsStart = name.Equals("start");
            IsEnd = name.Equals("end");
            Name = name;
            IsSmall = name.Equals(name.ToLower());
        }

        public bool CanVisit(VisitingStrategy.VisitingStrategy strategy, List<Cave> path)
        {
            if ((IsStart || IsEnd) && path.Contains(this))
                return false;

            if (path.Count > 0 && path.Last().Equals(this))
                return false;

            if (!strategy.CanVisit(this, path))
                return false;

            return true;
        }

        public void Connect(Cave other)
        {
            Connections.Add(other);
            other.Connections.Add(this);
        }

        public override bool Equals(object obj)
        {
            return obj is Cave cave &&
                   Name == cave.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public void Visit(ref List<Cave[]> paths, VisitingStrategy.VisitingStrategy strategy, List<Cave> currentPath)
        {
            currentPath.Add(this);
            if (IsEnd)
            {
                paths.Add(currentPath.ToArray());
                return;
            }

            foreach (var c in Connections)
            {
                if (c.CanVisit(strategy, currentPath))
                    c.Visit(ref paths, strategy, currentPath.ToList());
            }
        }

        public override string ToString() => Name;
    }
}
