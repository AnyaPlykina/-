using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class Program
    {
        ////находит среднее число и выводит два числа близких к нему
        //static (int,int) Function(int[] mas)
        //{
        //    double averageNum = mas.Average();
        //    Array.Sort(mas);
        //    int num1 = 0;
        //    int num2 = 0;
        //    foreach (int i in mas)
        //    {
        //        if (i > averageNum)
        //        {
        //            num2 = i; break;
        //        }
        //    }
        //    Array.Reverse(mas);
        //    foreach (int i in mas)
        //    {
        //        if (i < averageNum)
        //        {
        //            num1 = i; break;
        //        }
        //    }
        //    if (num1 == 0 && num2 == 0)
        //    {
        //        num1 = (int)averageNum;
        //        num2 = (int)averageNum;
        //    }
        //    return (num1, num2);
        //}
        //static List<Sea> Menu()
        //{
        //    Factory factory = new Factory();
        //    while (true)
        //    {
        //        Console.WriteLine("1. Добавить новый объект.");
        //        Console.WriteLine("2. Показать список всех объектов.");
        //        Console.WriteLine("3. Выход");
        //        Console.WriteLine("\nВведите число:");
        //        string input = Console.ReadLine();

        //        switch (input)
        //        {
        //            case "1":
        //                Console.WriteLine("\nНапишите название, глубину и соленость моря:");

        //                string str = Console.ReadLine();
        //                Sea sea = factory.CreateSeas(str);

        //                factory.AddSeas(sea);

        //                Console.WriteLine();

        //                break;

        //            case "2":
        //                Console.WriteLine("\nВсе моря:");
        //                foreach (Sea sea1 in factory.seas)
        //                {
        //                    Console.WriteLine($"Название: {sea1.Name}; глубина: {sea1.Depth}; соленость: {sea1.Salinity}");
        //                }
        //                Console.WriteLine();
        //                break;

        //            case "3":
        //                return factory.seas;


        //            default:
        //                Console.WriteLine("\nВведите корректное число.\n");
        //                break;
        //        }
        //    }
        //}
        //static void Fill(List<Point> points)
        //{
        //    int id = 0;
        //    Point point = points[id];
        //    int x = point.x;
        //    int y = point.y;
        //    char symbol1 = point.symbol;
        //    while (point.symbol == symbol1)
        //    {
        //        Point point1 = new Point(x, y + 1);
        //        Point point2 = new Point(x, y - 1);
        //        Point point3 = new Point(x + 1, y);
        //        Point point4 = new Point(x - 1, y);
        //        points.Add(point1);
        //        points.Add(point2);
        //        points.Add(point3);
        //        points.Add(point4);
        //        point.symbol = '*';
        //        id++;
        //        point = points[id];
        //        x = point.x;
        //        y = point.y;
        //        //symbol = point.symbol;
        //    }

        //}
        static void Main(string[] args)
        {
            List<Sea> seas = new List<Sea>();
            Factory factory = new Factory();
            while (true)
            {
                Console.WriteLine("1. Считать с файла.");
                Console.WriteLine("2. Считать с консоли.");
                Console.WriteLine("3. Показать список всех объектов.");
                Console.WriteLine("4. Записать в файл.");
                Console.WriteLine("5. Выход");
                Console.WriteLine("\nВведите число:");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        string[] lines = File.ReadAllLines("C:\\Users\\Родион\\-\\ProectIS\\laba2.txt");
                        foreach (string line in lines)
                        {
                            List<string> prop = factory.Splitting(line);
                            if (prop.Count() == 6)
                            {
                                prop.RemoveAt(1);

                                if (prop[4] == "да") prop[4] = "true";
                                else if (prop[4] == "нет") prop[4] = "false";
                            }

                            Sea s = factory.CreateSea(prop);
                            seas.Add(s);
                        }
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine("\nНапишите вид моря (море, окраинное, внутреннее, межостровное)");
                        string type = Console.ReadLine();

                        Console.WriteLine("\nНапишите название, глубину и соленость моря (через пробел):");
                        string str = Console.ReadLine();
                        List<string> properties = factory.Splitting(str);
                        properties.Insert(0, type.ToLower());

                        if (type.ToLower() == "окраинное")
                        {
                            Console.WriteLine("\nНапишите название океана, которому море принадлежит:");
                            string nameOcean = Console.ReadLine();
                            properties.Add(nameOcean);
                        }
                        else if (type.ToLower() == "внутреннее")
                        {
                            Console.WriteLine("\nОбладает высокой испаряемостью?");
                            string isHighlyEvaporating = Console.ReadLine();
                            properties.Add(isHighlyEvaporating);
                            if (properties[4] == "да") properties[4] = "true";
                            else if (properties[4] == "нет") properties[4] = "false";
                        }
                        if (type.ToLower() == "межостровное")
                        {
                            Console.WriteLine("\nНапишите количество островов, которые окружают море:");
                            string surroundingIslandsCount = Console.ReadLine();
                            properties.Add(surroundingIslandsCount);
                        }
                        Sea sea = factory.CreateSea(properties);
                        seas.Add(sea);

                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine("\nВсе моря:");
                        foreach (Sea sea1 in seas)
                        {
                            Console.WriteLine(sea1.Print());
                        }
                        Console.WriteLine();
                        break;

                    case "4":
                        string text = "";
                        foreach (Sea sea1 in seas)
                        {
                            text += sea1.Print();
                            text += "\n";
                        }
                        string path = "C:\\Users\\Родион\\-\\ProectIS\\output.txt";
                        File.WriteAllText(path, text);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("\nВведите корректное число.\n");
                        break;
                }
            }



            //string[] lines = File.ReadAllLines("C:\\Users\\Родион\\Desktop\\задание1.txt");
            //Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            //foreach (string line in lines)
            //{
            //    string newLine = line.Replace("->", "-");
            //    string[] str = newLine.Split('-');
            //    string mainVertex = str[0];
            //    string vertex = str[1];
            //    List<string> list = new List<string>();
            //    list.Add(str[1]);
            //    if (!dict.ContainsKey(mainVertex))
            //    {
            //        dict.Add(mainVertex, list);
            //    }
            //    else if (!dict[mainVertex].Contains(vertex))
            //    {
            //        dict[mainVertex].Add(vertex);
            //    }
            //}

            //foreach (string key in dict.Keys)
            //{
            //    Console.Write($"{key}: ");
            //    foreach (string value in dict[key])
            //    {
            //        Console.Write(value + " ");
            //    }
            //    Console.WriteLine();
            //}


            ////Menu();
            ////int[] ints = { 1, 2, 3, 4, 5};
            ////Console.WriteLine(Function(ints));
            //string[] lines = File.ReadAllLines("C:\\Users\\Родион\\-\\ProectIS\\laba1.txt");
            //int count = lines.Length;
            //int len = lines[0].Length;

            //string str = string.Join("", lines);
            //char[] mas = str.ToCharArray();

            //char[,] matrix = new char[count, len];

            //for (int i = 0; i < count; i++)
            //{
            //    for (int j = 0; j < len; j++)
            //    {
            //        matrix[i, j] = mas[i * len + j];
            //        Console.Write(mas[i * len + j]);
            //    }
            //    Console.WriteLine();
            //}

            //int x = int.Parse(Console.ReadLine());
            //int y = int.Parse(Console.ReadLine());

            //Point point = new Point();
            //point.x = x;
            //point.y = y;
            //point.symbol = matrix[x, y];
        }
    }
}
