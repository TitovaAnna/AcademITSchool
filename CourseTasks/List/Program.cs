using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrayLine = List.ListCreate();
            foreach (string s in arrayLine)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();

            List<int> listInt = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                listInt.Add(i);
            }

            List.DeleteEven(listInt);

            foreach (int s in listInt)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();

            List<int> list = new List<int>() { 3, 4, 2, 4, 6, 7, 2, 3, 1 };
            IEnumerable<int> distinctList = List.Distinct(list);

            foreach (int s in distinctList)
            {
                Console.WriteLine(list.ToString());
            }
            Console.ReadKey();
        }
    }
}
