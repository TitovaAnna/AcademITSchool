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

            List<string> arrayLine = ReadFile(args[0]);

            if (arrayLine == null)
            {
                Console.WriteLine("Ошибка чтения файла");
                Console.ReadKey();
                return;
            }

            if (args[2].Equals("-i"))
            {
                try
                {
                    List<int> arrayDigital = arrayLine.ConvertAll(new Converter<string, int>(Convert.ToInt32));
                    if (args[3].Equals("-a"))
                    {
                        arrayLine = Sort(arrayDigital, true);
                    }
                    else if (args[3].Equals("-d"))
                    {
                        arrayLine = Sort(arrayDigital, false);
                    }
                    else
                    {
                        Console.WriteLine("Неправильно задан тип сортировки");
                        Console.ReadKey();
                        return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Невозможно преобразовать данные в число");
                    Console.ReadKey();
                }
            }
            else if (args[2].Equals("-s"))
            {
                if (args[3].Equals("-a"))
                {
                    Sort(arrayLine, true);
                }
                else if (args[3].Equals("-d"))
                {
                    Sort(arrayLine, false);
                }
                else
                {
                    Console.WriteLine("Неправильно задан тип сортировки");
                    Console.ReadKey();
                    return;
                }

            }
            else
            {
                Console.WriteLine("Неправильно задан тип данных");
                Console.ReadKey();
                return;
            }

            WriteFile(args[1], arrayLine);
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
        public static List<string> Sort(List<int> arrayDigital, bool increase)
        {
            for (int i = 1; i < arrayDigital.Count; i++)
            {
                int temp = arrayDigital[i];
                int j = i - 1;
                if (increase)
                {
                    while ((j >= 0) && (arrayDigital[j] > temp))
                    {
                        arrayDigital[j + 1] = arrayDigital[j];
                        j--;
                    }
                    arrayDigital[j + 1] = temp;

                }
                else
                {
                    while ((j >= 0) && (arrayDigital[j] < temp))
                    {
                        arrayDigital[j + 1] = arrayDigital[j];
                        j--;
                    }
                    arrayDigital[j + 1] = temp;
                }
            }
            return arrayDigital.ConvertAll(new Converter<int, string>(Convert.ToString));
        }

        public static void Sort(List<string> arrayLine, bool increase)
        {
            for (int i = 1; i < arrayLine.Count; i++)
            {
                string temp = arrayLine[i];
                int j = i - 1;

                if (increase)
                {
                    while ((j >= 0) && (arrayLine[j].CompareTo(temp) > 0))
                    {
                        arrayLine[j + 1] = arrayLine[j];
                        j--;
                    }
                    arrayLine[j + 1] = temp;
                    return;
                }

                while ((j >= 0) && (arrayLine[j].CompareTo(temp) < 0))
                {
                    arrayLine[j + 1] = arrayLine[j];
                    j--;
                }
                arrayLine[j + 1] = temp;

            }

        }

        public static void WriteFile(string fileNameOut, List<string> arrayLine)
        {
            using (StreamWriter writer = new StreamWriter(fileNameOut))
            {
                foreach (string s in arrayLine)
                {
                    writer.WriteLine(s);
                }

            }
        }
    }

}

