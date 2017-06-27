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
        public static void ReadCSV()
        {
            string textCSV = File.ReadAllText("CSV.txt", Encoding.Default);
            StringBuilder textHTML = new StringBuilder();

            File.AppendAllText("html.html", "\n<table>\n");
            File.AppendAllText("html.html", "\n<tr>\n");
            File.AppendAllText("html.html", "<td>");

            bool quoteOpen = false;
            bool pair = false;

            for (int i = 0; i < textCSV.Length; i++)
            {
                char ch = textCSV[i];
                char chNext = ' ';

                if (i != textCSV.Length - 1)
                {
                    chNext = textCSV[i + 1];
                }

                if ((ch == ',') && (quoteOpen))
                {
                    textHTML.Append(ch);
                }
                else if (((ch == '\n')) && (quoteOpen))
                {
                    textHTML.Append("<br/>");
                }
                else if (((ch == ',') && (!quoteOpen)))
                {
                    textHTML.Append("</td><td>");
                }
                else if (((ch == '\n') && (!quoteOpen)))
                {
                    textHTML.Append("</td>\n</tr>\n<tr>\n<td>");
                }
                else if (ch == '"')
                {
                    if (pair)
                    {
                        pair = false;
                    }
                    else if (chNext == ch)
                    {
                        textHTML.Append('"');
                        pair = true;
                    }
                    else if ((chNext != ch) && (quoteOpen))
                    {
                        textHTML.Append("</td><td>");
                        quoteOpen = false;
                    }
                    else if ((chNext != ch) && (!quoteOpen))
                    {
                        textHTML.Append("<td>");
                        quoteOpen = true;
                    }
                }
                else
                {
                    textHTML.Append(ch);
                }
            }
            File.AppendAllText("html.html", textHTML.ToString());
            File.AppendAllText("html.html", "\n</table>\n");
        }
    }
}
