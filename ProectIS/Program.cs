using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProectIS
{
    public class Program
    {
        //находит среднее число и выводит два числа близких к нему
        static (int,int) Function(int[] mas)
        {
            double averageNum = mas.Average();
            Array.Sort(mas);
            int num1 = 0;
            int num2 = 0;
            foreach (int i in mas)
            {
                if (i > averageNum)
                {
                    num2 = i; break;
                }
            }
            Array.Reverse(mas);
            foreach (int i in mas)
            {
                if (i < averageNum)
                {
                    num1 = i; break;
                }
            }
            if (num1 == 0 && num2 == 0)
            {
                num1 = (int)averageNum;
                num2 = (int)averageNum;
            }
            return (num1, num2);
        }
        static List<Sea> Menu()
        {
            Factory factory = new Factory();
            while (true)
            {
                Console.WriteLine("1. Добавить новый объект.");
                Console.WriteLine("2. Показать список всех объектов.");
                Console.WriteLine("3. Выход");
                Console.WriteLine("\nВведите число:");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("\nНапишите название, глубину и соленость моря:");

                        string str = Console.ReadLine();
                        Sea sea = factory.CreateSeas(str);

                        factory.AddSeas(sea);

                        Console.WriteLine();

                        break;

                    case "2":
                        Console.WriteLine("\nВсе моря:");
                        foreach (Sea sea1 in factory.seas)
                        {
                            Console.WriteLine($"Название: {sea1.Name}; глубина: {sea1.Depth}; соленость: {sea1.Salinity}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        return factory.seas;


                    default:
                        Console.WriteLine("\nВведите корректное число.\n");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            //Menu();
            //int[] ints = { 1, 2, 3, 4, 5};
            //Console.WriteLine(Function(ints));
            string[] lines = File.ReadAllLines("C:\\Users\\Родион\\-\\ProectIS\\laba1.txt");
            int count = lines.Length;
            int len = lines[0].Length;

            string str = string.Join("", lines);
            char[] mas = str.ToCharArray();

            char[,] matrix = new char[count, len];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    matrix[i, j] = mas[i * len + j];
                    Console.Write(mas[i * len + j]);
                }
                Console.WriteLine();
            }

            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (x > 0 && x < len && y > 0 && y < count)
            {
                if (matrix[x, y] == '.' && matrix[x, y + 1] == '.')
                {
                    matrix[x, y] = '#';
                    matrix[x, y + 1] = '#';
                    Console.WriteLine(matrix[x, y] + " " + matrix[x, y + 1]);
                }
                if (matrix[x, y] == '.' && matrix[x, y - 1] == '.')
                {
                    matrix[x, y] = '#';
                    matrix[x, y + 1] = '#';
                    Console.WriteLine(matrix[x, y] + " " + matrix[x, y - 1]);
                }
                if (matrix[x, y] == '.' && matrix[x + 1, y] == '.')
                {
                    matrix[x, y] = '#';
                    matrix[x, y + 1] = '#';
                    Console.WriteLine(matrix[x, y] + " " + matrix[x + 1, y]);
                }
                if (matrix[x, y] == '.' && matrix[x - 1, y] == '.')
                {
                    matrix[x, y] = '#';
                    matrix[x, y + 1] = '#';
                    Console.WriteLine(matrix[x, y] + " " + matrix[x - 1, y]);
                }
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    matrix[i, j] = mas[i * len + j];
                    Console.Write(mas[i * len + j]);
                }
                Console.WriteLine();
            }
        }
    }
}
