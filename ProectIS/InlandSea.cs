using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class InlandSea : Sea
    {
        public bool IsHighlyEvaporating { get; set; }
        public InlandSea(string name, double depth, double salinity, bool isHighlyEvaporating) : base(name, depth, salinity)
        {
            IsHighlyEvaporating = isHighlyEvaporating;
        }
        public override string Print()
        {
            string s = "";
            s += $"Родитель: {this.GetType().BaseType.Name}; название: {Name}; глубина: {Depth}; соленость: {Salinity}; обладает высокой испаряемостью: {IsHighlyEvaporating}";
            return s;
        }
    }
}
