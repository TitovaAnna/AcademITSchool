using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortOOP
{
    static class DataIO
    {
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
