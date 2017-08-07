using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine(@"Необходимо ввести аргументы:
имя входного файла
имя выходного файла
тип данных: ""-i""-числа,""-s""-строки
вид сортировки: ""-a""-по возрастанию,""-d""-по убыванию");
                Console.ReadKey();
                return;
            }

            List<string> listStrings = new List<string>();
            try
            {
                listStrings = DataIO.ReadFile(args[0]);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл {0} не найден", args[0]);
                Console.ReadKey();
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка чтения файла {0}", args[0]);
                Console.ReadKey();
                return;
            }

            bool numbers = args[2].Equals("-i");
            bool strings = args[2].Equals("-s");
            bool increase = args[3].Equals("-a");
            bool decrease = args[3].Equals("-d");

            if (!increase && !decrease)
            {
                Console.WriteLine("Тип сортировки задается аргументами \"-a\"-по возрастанию,\"-d\"-по убыванию");
                Console.ReadKey();
                return;
            }

            if (numbers)
            {

                try
                {
                    List<int> listNumbers = new List<int>();
                    listNumbers = listStrings.ConvertAll(Convert.ToInt32);
                    SortOOP.Sort(listNumbers, increase);
                    listStrings = listNumbers.ConvertAll(Convert.ToString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Невозможно преобразовать данные в число");
                    Console.ReadKey();
                    return;
                }

            }
            else if (strings)
            {
                SortOOP.Sort(listStrings, increase);
            }
            else
            {
                Console.WriteLine("Тип данных задается аргументами:\"-i\"-числа,\"-s\"-строки");
                Console.ReadKey();
                return;
            }

            try
            {
                DataIO.WriteFile(args[1], listStrings);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка записи файла {0}", args[1]);
                Console.ReadKey();
            }
        }
    }
}
