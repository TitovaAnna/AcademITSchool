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
            if (args.Length < 3)
            {
                Console.WriteLine("Не хватает аргументов командной строки");
                Console.ReadKey();
            }
            else
            {
                int position = args[2].IndexOf("txt");

                if (args[2][position + 6].Equals('a') && args[2][position + 4].Equals('i'))
                {
                    Sort(args[1], args[2].Remove(position + 3), true);
                }
                else if (args[2][position + 6].Equals('d') && args[2][position + 4].Equals('i'))
                {
                    Sort(args[1], args[2].Remove(position + 3), false);

                }
                else if (args[2][position + 4].Equals('s'))
                {
                    Sort(args[1], args[2].Remove(position + 3));
                }

            }

        }

        public static void Sort(string fileNameIn, string fileNameOut, bool increas)
        {
            try
            {

                int[] arrayDigital;
                List<string> arrayLine = new List<string>();

                using (StreamReader reader = new StreamReader(fileNameIn))
                {
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        arrayLine.Insert(i, reader.ReadLine());
                        Console.WriteLine(arrayLine[i]);
                        Console.ReadKey();
                        i++;
                    }
                }

                arrayDigital = Array.ConvertAll(arrayLine.ToArray(), Convert.ToInt32);

                for (int i = 1; i < arrayDigital.Length; i++)
                {
                    int temp = arrayDigital[i];
                    int j = i - 1;
                    if (increas)
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

                using (StreamWriter writer = new StreamWriter(fileNameOut))
                {
                    foreach (int i in arrayDigital)
                    {
                        writer.WriteLine(i);
                    }

                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                Console.ReadKey();
                return;
            }
        }
        public static void Sort(string fileNameIn, string fileNameOut)
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
                for (int i = 1; i < arrayLine.Count; i++)
                {
                    string temp = arrayLine[i];
                    int j = i - 1;
                    while ((j >= 0) && (arrayLine[j].CompareTo(temp) > 0))
                    {
                        arrayLine[j + 1] = arrayLine[j];
                        j--;
                    }
                    arrayLine[j + 1] = temp;
                }

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
                return;
            }
        }

    }
}
