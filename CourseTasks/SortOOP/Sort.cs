using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortOOP
{
    class SortOOP<T> where T : IComparable
    {
        public static void Sort(List<T> list, bool increase)
        {
            for (int i = 1; i < list.Count; i++)
            {
                T temp = list[i];
                int j = i - 1;
                {
                    while ((j >= 0) && (Compare(list[j], temp, increase)))
                    {
                        list[j + 1] = list[j];
                        j--;
                    }
                    list[j + 1] = temp;
                }
            }
        }
        private static bool Compare(T data1, T data2, bool increase)
        {
            return ((data1.CompareTo(data2) > 0) && (increase) || ((data1.CompareTo(data2) < 0) && (!increase)));
        }
    }
}
