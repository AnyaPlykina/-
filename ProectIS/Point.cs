using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    internal class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public char symbol { get; set; }
        public Point(int x1, int y1)
        {
            x = x1;
            y = y1;
        }
    }
}
