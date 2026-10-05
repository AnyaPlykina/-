using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class Sea
    {
        public string Name {  get; set; }
        public double Depth { get; set; }
        public double Salinity { get; set; }
        public Sea(string name, double depth, double salinity)
        {
            Name = name;
            Depth = depth;
            Salinity = salinity;
        }
        public virtual string NameTypeParent => "-";
        public virtual string Print()
        {
            string s = "";
            s += $" название: {Name}; глубина: {Depth}; соленость: {Salinity}";
            return s;
        }
    }
}
