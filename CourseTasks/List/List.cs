using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace List
{
    class List
    {
        public static List<string> ListCreate()
        {
            string fileName = "1.txt";
            List<string> arrayLine = new List<string>();
            using (StreamReader reader = new StreamReader(fileName, Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    arrayLine.Add(reader.ReadLine());
                }
            }
            return arrayLine;
        }

        public static void DeleteEven(List<int> list)
        {
            list.RemoveAll(isEven);
        }

        public static IEnumerable<int> Distinct(List<int> list)
        {
            return list.Distinct();
        }

        private static bool isEven(int i)
        {
            return i % 2 == 0;
        }
    }
}
