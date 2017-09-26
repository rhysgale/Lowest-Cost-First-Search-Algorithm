using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lowest_Cost_First_Search
{
    class Path
    {
        public Node locationA { get; set; }
        public Node locationB { get; set; }

        public int distance { get; set; }

        public Path(Node locA, Node locB, int dist)
        {
            locationA = locA;
            locationB = locB;
            distance = dist;
        }
    }
}
