using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ProectIS
{
    public class Factory
    {
        public List<Sea> seas {  get; set; } = new List<Sea>();
        public Sea CreateSeas(string str)
        {
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            string[] prop = str.Split(' ');

            Sea sea = new Sea();
            sea.Name = prop[prop.Length - 3];
            sea.Depth = double.Parse(prop[prop.Length - 2], CultureInfo.InvariantCulture);
            sea.Salinity = double.Parse(prop[prop.Length - 1], CultureInfo.InvariantCulture);

            return sea;
        }
        public void AddSeas(Sea sea)
        {
            seas.Add(sea);
        }
    }
}
