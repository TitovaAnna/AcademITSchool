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
            int i = 0;

            while (i < list.Count)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public static List<int> Distinct(List<int> list)
        {
            List<int> listDistinct = new List<int>();
            foreach (int i in list)
            {
                if (!listDistinct.Contains(i))
                {
                    listDistinct.Add(i);
                }
            }
            return listDistinct;
        }
    }
}
