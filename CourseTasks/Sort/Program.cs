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

            string[] arrayLine = ReadFile(args[0]);

            if (arrayLine == null)
            {
                return;
            }

            arrayLine = Sort(arrayLine, args[2].ToLower(), args[3].ToLower());

            if (arrayLine == null)
            {
                return;
            }
            WriteFile(args[1], arrayLine);
        }

        public static string[] ReadFile(string fileNameIn)
        {
            try
            {
                List<string> arrayLine = new List<string>();

                using (StreamReader reader = new StreamReader(fileNameIn, Encoding.Default))
                {
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        arrayLine.Insert(i, reader.ReadLine());
                        i++;
                    }
                }

                return arrayLine.ToArray();
            }

            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                Console.ReadKey();
                return null;
            }
        }
        public static string[] Sort(string[] arrayLine, string type, string order)
        {
            try
            {
                if (type.Equals("-i"))
                {
                    int[] arrayDigital = Array.ConvertAll(arrayLine, Convert.ToInt32);

                    for (int i = 1; i < arrayDigital.Length; i++)
                    {
                        int temp = arrayDigital[i];
                        int j = i - 1;
                        if (order.Equals("-a"))
                        {
                            while ((j >= 0) && (arrayDigital[j] > temp))
                            {
                                arrayDigital[j + 1] = arrayDigital[j];
                                j--;
                            }
                            arrayDigital[j + 1] = temp;
                        }
                        else if (order.Equals("-d"))
                        {
                            while ((j >= 0) && (arrayDigital[j] < temp))
                            {
                                arrayDigital[j + 1] = arrayDigital[j];
                                j--;
                            }
                            arrayDigital[j + 1] = temp;
                        }
                        else
                        {
                            Console.WriteLine("Не правильно задан порядок сортировки");
                            Console.ReadKey();
                            return null;
                        }
                    }
                    return Array.ConvertAll(arrayDigital, Convert.ToString);
                }
                else if (type.Equals("-s"))
                {
                    for (int i = 1; i < arrayLine.Length; i++)
                    {
                        string temp = arrayLine[i];
                        int j = i - 1;

                        if (order.Equals("-a"))
                        {
                            while ((j >= 0) && (arrayLine[j].CompareTo(temp) > 0))
                            {
                                arrayLine[j + 1] = arrayLine[j];
                                j--;
                            }
                            arrayLine[j + 1] = temp;
                        }
                        else if (order.Equals("-d"))
                        {
                            while ((j >= 0) && (arrayLine[j].CompareTo(temp) < 0))
                            {
                                arrayLine[j + 1] = arrayLine[j];
                                j--;
                            }
                            arrayLine[j + 1] = temp;
                        }
                        else
                        {
                            Console.WriteLine("Не правильно задан порядок сортировки");
                            Console.ReadKey();
                            return new string[] { };
                        }
                    }
                    return arrayLine;
                }
                Console.WriteLine("Не правильно задан тип данных");
                Console.ReadKey();
                return null;
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                Console.ReadKey();
                return null;

            }
        }
        public static void WriteFile(string fileNameOut, string[] arrayLine)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileNameOut))
                {
                    foreach (string s in arrayLine)
                    {
                        writer.WriteLine(s);
                    }

                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                Console.ReadKey();
            }
        }


    }
}
