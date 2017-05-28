using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Не хватает аргументов командной строки");
                Console.ReadKey();
                return;
            }

            List<string> listStrings = new List<string>();
            try
            {
                listStrings = ReadFile(args[0]);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл {0} не найден", args[0]);
                Console.ReadKey();
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка чтения файла {0}", args[0]);
                Console.ReadKey();
                return;
            }

            bool numbers = args[2].Equals("-i");
            bool strings = args[2].Equals("-s");
            bool increase = args[3].Equals("-a");
            bool decrease = args[3].Equals("-d");

            if (!increase && !decrease)
            {
                Console.WriteLine("Неправильно задан тип сортировки");
                Console.ReadKey();
                return;
            }

            if (numbers)
            {
                List<int> listNumbers = new List<int>();
                try
                {
                    listNumbers = listStrings.ConvertAll(new Converter<string, int>(Convert.ToInt32));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Невозможно преобразовать данные в число");
                    Console.ReadKey();
                    return;
                }
                Sort(listNumbers, increase);
                listStrings = listNumbers.ConvertAll(Convert.ToString);
            }
            else if (strings)
            {
                Sort(listStrings, increase);
            }
            else
            {
                Console.WriteLine("Неправильно задан тип данных");
                Console.ReadKey();
                return;
            }

            try
            {
                WriteFile(args[1], listStrings);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка записи файла {0}", args[1]);
                Console.ReadKey();
            }
        }

        public static List<string> ReadFile(string fileNameIn)
        {
            List<string> arrayLine = new List<string>();
            using (StreamReader reader = new StreamReader(fileNameIn, Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    arrayLine.Add(reader.ReadLine());
                }
            }
            return arrayLine;
        }

        public static void Sort(List<int> listNumbers, bool increase)
        {
            for (int i = 1; i < listNumbers.Count; i++)
            {
                int temp = listNumbers[i];
                int j = i - 1;
                if (increase)
                {
                    while ((j >= 0) && (listNumbers[j] > temp))
                    {
                        listNumbers[j + 1] = listNumbers[j];
                        j--;
                    }
                    listNumbers[j + 1] = temp;
                }
                else
                {
                    while ((j >= 0) && (listNumbers[j] < temp))
                    {
                        listNumbers[j + 1] = listNumbers[j];
                        j--;
                    }
                    listNumbers[j + 1] = temp;
                }
            }
        }

        public static void Sort(List<string> listStrings, bool increase)
        {
            for (int i = 1; i < listStrings.Count; i++)
            {
                string temp = listStrings[i];
                int j = i - 1;
                if (increase)
                {
                    while ((j >= 0) && (listStrings[j].CompareTo(temp) > 0))
                    {
                        listStrings[j + 1] = listStrings[j];
                        j--;
                    }
                    listStrings[j + 1] = temp;
                }
                else
                {
                    while ((j >= 0) && (listStrings[j].CompareTo(temp) < 0))
                    {
                        listStrings[j + 1] = listStrings[j];
                        j--;
                    }
                    listStrings[j + 1] = temp;
                }
            }
        }

        public static void WriteFile(string fileNameOut, List<string> listStrings)
        {
            using (StreamWriter writer = new StreamWriter(fileNameOut))
            {
                foreach (string s in listStrings)
                {
                    writer.WriteLine(s);
                }
            }
        }
    }
}

