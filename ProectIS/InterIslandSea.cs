using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class InterIslandSea : Sea
    {
        public int SurroundingIslandsCount { get; set; }
        public InterIslandSea(string name, double depth, double salinity, int surroundingIslandsCount) : base(name, depth, salinity)
        {
            SurroundingIslandsCount = surroundingIslandsCount;
        }
        public override string ToString()
        {
            string s = "";
            s += $"Родитель: {this.GetType().BaseType.Name}; название: {Name}; глубина: {Depth}; соленость: {Salinity}; количество окружающих островов: {SurroundingIslandsCount}";
            return s;
        }
    }
}
