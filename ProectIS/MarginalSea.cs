using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class MarginalSea : Sea
    {
        public string OceanName { get; set; }
        public MarginalSea(string str) : base("", 0, 0)
        {
            Factory factory = new Factory();
            List<string> prop = factory.Splitting(str);
            if (prop.Count() == 6)
            {
                prop.RemoveAt(1);
            }
            Name = prop[1];
            Depth = double.Parse(prop[2], CultureInfo.InvariantCulture);
            Salinity = double.Parse(prop[3], CultureInfo.InvariantCulture);
            OceanName = prop[4];
        }
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
