using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class MarginalSea : Sea
    {
        public string OceanName { get; set; }
        public MarginalSea(string name, double depth, double salinity, string oceanName) : base(name, depth, salinity)
        {
            OceanName = oceanName;
        }
        public override string Print()
        {
            string s = "";
            s += $"Родитель: {this.GetType().BaseType.Name}; название: {Name}; глубина: {Depth}; соленость: {Salinity}; название океана: {OceanName}";
            return s;
        }
    }
}
