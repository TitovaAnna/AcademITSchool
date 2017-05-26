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

            List<string> listStrings = ReadFile(args[0]);

            if (listStrings == null)
            {
                Console.WriteLine("Ошибка чтения файла");
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
                try
                {
                    List<int> listNumbers = listStrings.ConvertAll(new Converter<string, int>(Convert.ToInt32));
                    if (increase)
                    {
                        Sort(listNumbers, true);
                    }
                    else if (decrease)
                    {
                        Sort(listNumbers, false);
                    }
                    WriteFile(args[1], listNumbers.ConvertAll<string>(Convert.ToString));
                }
                catch (Exception)
                {
                    Console.WriteLine("Невозможно преобразовать данные в число");
                    Console.ReadKey();
                }
            }
            else if (strings)
            {
                if (increase)
                {
                    Sort(listStrings, true);
                }
                else if (decrease)
                {
                    Sort(listStrings, false);
                }
                WriteFile(args[1], listStrings);
            }
            else
            {
                Console.WriteLine("Неправильно задан тип данных");
                Console.ReadKey();
                return;
            }
        }

        public static List<string> ReadFile(string fileNameIn)
        {
            try
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
            catch (Exception)
            {
                return null;
            }
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

