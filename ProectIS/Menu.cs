//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace ProectIS
//{
//    public class Menu
//    {
//        public List<Sea> seas { get; set; } = new List<Sea>();
//        public Factory factory { get; set; } = new Factory();

//        private readonly string _inPath = "laba2.txt";
//        private readonly string _outPath = "output.txt";
//        public void ProcessInput(string input)
//        {   
//            switch (input)
//            {
//                case "1": LoadFromFile(_inPath); break;
//                case "2": LoadFromConsole(); break;
//                case "3": PrintAllSeas(); break;
//                case "4": SaveToFile(_outPath); break;
//                default: Console.WriteLine("Некорректный ввод."); break;
//            }
//        }
//        public static void LoadFromFile(string path)
//        {
//            try
//            {
//                foreach (string line in File.ReadAllLines(path))
//                {
//                    var prop = factory.Splitting(line);
//                    NormalizeFileProperties(prop);
//                    AddSeaToList(factory.CreateSea(prop), seas);
//                }
//                AppLogger.Instance.Info("Загружено из файла.");
//            }
//            catch (Exception ex) { AppLogger.Instance.PError("Ошибка чтения", ex); }
//        }

//        public static void NormalizeFileProperties(List<string> prop)
//        {
//            if (prop.Count != 6) return;
//            prop.RemoveAt(1);
//            if (prop[4].ToLower() == "да") prop[4] = "true";
//            else if (prop[4].ToLower() == "нет") prop[4] = "false";
//        }

//        public static void LoadFromConsole(List<Sea> seas, Factory factory)
//        {
//            try
//            {
//                Console.WriteLine("\nВид (море, окраинное, внутреннее, межостровное):");
//                string type = Console.ReadLine().ToLower();

//                Console.WriteLine("Название, глубина, соленость (через пробел):");
//                var props = factory.Splitting(Console.ReadLine());
//                props.Insert(0, type);

//                RequestSpecificProperties(type, props);
//                AddSeaToList(factory.CreateSea(props), seas);
//            }
//            catch (Exception ex) { AppLogger.Instance.PError("Ошибка консоли", ex); }
//        }

//        public static void RequestSpecificProperties(string type, List<string> props)
//        {
//            if (type == "окраинное") props.Add(GetInput("Океан:"));
//            else if (type == "внутреннее") props.Add(GetBooleanInput("Высокая испаряемость (да/нет):"));
//            else if (type == "межостровное") props.Add(GetInput("Количество островов:"));
//        }

//        public static string GetInput(string message)
//        {
//            Console.WriteLine(message);
//            return Console.ReadLine();
//        }

//        public static string GetBooleanInput(string message)
//        {
//            string val = GetInput(message).ToLower();
//            return val == "да" ? "true" : "false";
//        }

//        public static void AddSeaToList(Sea sea, List<Sea> seas)
//        {
//            if (sea != null)
//            {
//                seas.Add(sea);
//                AppLogger.Instance.Info("Добавлено.");
//            }
//        }

//        public static void PrintAllSeas(List<Sea> seas)
//        {
//            if (seas.Count == 0) Console.WriteLine("Список пуст.");
//            else
//            {
//                Console.WriteLine("\nВсе моря:");
//                foreach (Sea sea1 in seas) Console.WriteLine(sea1.ToString());
//            }
//        }

//        public static void SaveToFile(string path, List<Sea> seas)
//        {
//            try
//            {
//                string text = "";
//                foreach (Sea sea1 in seas) text += sea1.ToString();
//                File.WriteAllText(path, text);
//                AppLogger.Instance.Info("Сохранено.");
//            }
//            catch (Exception ex) { AppLogger.Instance.PError("Ошибка записи", ex); }
//        }
//    }
//}
//}
