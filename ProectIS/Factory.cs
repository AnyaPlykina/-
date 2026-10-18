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
            try
            {
                ValidateProperties(prop);
                return InstanciateSea(prop);
            }
            catch (Exception ex)
            {
                Logger.Instance.PError("Ошибка при создании объекта Sea", ex);
                return null;
            }
        }

        private Sea InstanciateSea(List<string> prop)
        {
            double depth = double.Parse(prop[2], CultureInfo.InvariantCulture);
            double salinity = double.Parse(prop[3], CultureInfo.InvariantCulture);

            switch (prop[0].ToLower())
            {
                case "окраинное": return new MarginalSea(prop[1], depth, salinity, prop[4]);
                case "внутреннее": return new InlandSea(prop[1], depth, salinity, bool.Parse(prop[4]));
                case "межостровное": return new InterIslandSea(prop[1], depth, salinity, int.Parse(prop[4]));
                case "море": return new Sea(prop[1], depth, salinity);
                default:
                    Logger.Instance.Info($"Неизвестный тип моря: {prop[0]}");
                    return null;
            }
        }
        private void ValidateProperties(List<string> prop)
        {
            if (prop == null || prop.Count < 4)
                throw new ArgumentException("Недостаточно аргументов для создания моря.");
        }

        public List<string> Splitting(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return new List<string>();
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            string[] prop = str.Trim().Split(' ');
            return prop.ToList();
        }
    }
}
