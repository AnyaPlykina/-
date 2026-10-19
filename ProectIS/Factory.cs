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
                AppLogger.Instance.PError("Ошибка при создании объекта Sea", ex);
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
                    AppLogger.Instance.Info($"Неизвестный тип моря: {prop[0]}");
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
        //1 положительное последнее отрицательное сумму между ними
        public static int CalcSum(List<int> list)
        {
            int ind1 = -1;
            int ind2 = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0)
                {
                    ind1 = i;
                    break;
                }
            }
            for (int i = list.Count - 1; i > -1; i--)
            {
                if (list[i] < 0)
                {
                    ind2 = i;
                    break;
                }
            }
            int sum = 0;
            if (ind1 == -1 || ind2 == -1)
                return sum;

            if (ind2 < ind1)
            {
                for (int i = ind2+1; i <= ind1; i++)
                {
                    sum += list[i];
                }
                return sum;
            }
            else
            {
                for (int i = ind1+1; i <= ind2; i++)
                {
                    sum += list[i];
                }
                return sum;
            }
        }
    }
}
