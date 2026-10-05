using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ProectIS
{
    public class Factory
    {
        public Sea CreateSea(List<string> prop)
        {
            double depth = double.Parse(prop[2], CultureInfo.InvariantCulture);
            double salinity = double.Parse(prop[3], CultureInfo.InvariantCulture);
            
            switch (prop[0])
            {
                case "окраинное": return new MarginalSea(prop[1], depth, salinity, prop[4]);
                case "внутреннее": return new InlandSea(prop[1], depth, salinity, bool.Parse(prop[4]));
                case "межостровное": return new InterIslandSea(prop[1], depth, salinity, int.Parse(prop[4]));
                case "море": return new Sea(prop[1], depth, salinity);
                default: return null;
            }
        }

        public List<string> Splitting(string str)
        {
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            string[] prop = str.Split(' ');

            return prop.ToList();
        }
    }
}
