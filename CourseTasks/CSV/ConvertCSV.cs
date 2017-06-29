using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV
{
    class ConvertCSV
    {
        public static void ReadCSV(string fileNameIn, string fileNameOut)
        {
            string textCSV = File.ReadAllText(fileNameIn, Encoding.Default);
            StringBuilder textHTML = new StringBuilder();

            textHTML.Append("<!DOCTYPE html>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("<html>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("<head>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("<title>Таблица</title>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("</head>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("<body>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("<table>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("<tr>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("<td>");

            bool cellOpen = false;
            bool quoteAdded = false;

            for (int i = 0; i < textCSV.Length; i++)
            {
                char ch = textCSV[i];
                char chNext = ' ';
                int numberLast = textCSV.Length - 1;

                if (i != textCSV.Length - 1)
                {
                    chNext = textCSV[i + 1];
                }
                if ((ch == ',') && cellOpen)
                {
                    textHTML.Append(ch);
                }
                else if (((ch == '\n')) && cellOpen)
                {
                    textHTML.Append("<br/>");
                }
                else if ((ch == ',') && !cellOpen)
                {
                    textHTML.Append("</td><td>");
                }
                else if (ch == '"')
                {
                    if (!cellOpen)
                    {
                        cellOpen = true;
                    }
                    else if (quoteAdded)
                    {
                        quoteAdded = false;
                    }
                    else if (chNext == ch)
                    {
                        textHTML.Append('"');
                        quoteAdded = true;
                    }
                    else if (chNext != ch)
                    {
                        cellOpen = false;
                    }
                }
                else if ((ch == '\n') && !cellOpen)
                {
                    textHTML.Append("</td>");
                    textHTML.Append(Environment.NewLine);
                    textHTML.Append("</tr>");
                    textHTML.Append(Environment.NewLine);
                    if (i == textCSV.Length - 1)
                    {
                        break;
                    }
                    textHTML.Append("<tr>");
                    textHTML.Append(Environment.NewLine);
                    textHTML.Append("<td>");
                }
                else if (ch == '<')
                {
                    textHTML.Append("&lt");
                }
                else if (ch == '>')
                {
                    textHTML.Append("&gt");
                }
                else if (ch == '&')
                {
                    textHTML.Append("&amp");
                }
                else
                {
                    textHTML.Append(ch);
                }

                if (i == numberLast)
                {
                    textHTML.Append("</td>");
                    textHTML.Append(Environment.NewLine);
                    textHTML.Append("</tr>");
                }
            }
            textHTML.Append(Environment.NewLine);
            textHTML.Append("</table>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("</body>");
            textHTML.Append(Environment.NewLine);
            textHTML.Append("</html>");
            File.AppendAllText(fileNameOut, textHTML.ToString());
        }
    }
}

