using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortOOP
{
    static class SortOOP
    {
        public static void Sort<T>(List<T> list, bool increase) where T : IComparable
        {
            for (int i = 1; i < list.Count; i++)
            {
                T temp = list[i];
                int j = i - 1;
                {
                    while (j >= 0 && Compare(list[j], temp, increase))
                    {
                        list[j + 1] = list[j];
                        j--;
                    }
                    list[j + 1] = temp;
                }
            }
        }
        private static bool Compare<T>(T data1, T data2, bool increase) where T : IComparable
        {
            if (increase)
            {
                return data1.CompareTo(data2) > 0;
            }
            return data1.CompareTo(data2) < 0;
        }
    }
}
