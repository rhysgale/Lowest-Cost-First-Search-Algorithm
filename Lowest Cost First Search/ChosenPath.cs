using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lowest_Cost_First_Search
{
    class ChosenPath
    {
        public Node _LocationA { get; set; }
        public Node _LocationB { get; set; }
        public int _Distance { get; set; }

        public ChosenPath(Node locA, Node locB, int dist)
        {
            _LocationA = locA;
            _LocationB = locB;
            _Distance = dist;
        }
    }
}
