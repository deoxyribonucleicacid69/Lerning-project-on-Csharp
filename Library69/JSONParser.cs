using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс реализующий парсинг JSON-файла.
    /// </summary>
    public class JSONParser
    {
        /// <summary>
        /// Метод который парсит JSOn-файл.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="visitors"></param>
        /// <returns></returns>
        public List<Visitor> JSONParsing(string data,ref List<Visitor> visitors )
        {
            try
            {
                string pattern = @"(?<=\{\s*""elements""\s*:\s*\[)([\s\S]*)(?=\]\s*\})";
                Regex regex1 = new Regex(pattern);
                Match objects = regex1.Match(data);
                string patternNew = @"\{(?:[^{}]|(?<open>\{)|(?<-open>\}))*(?(open)(?!))\}";
                Regex regex = new Regex(patternNew, RegexOptions.Singleline);
                MatchCollection matches = Regex.Matches(objects.Value, patternNew, RegexOptions.Singleline);
                foreach (Match match in matches)
                {
                    visitors.Add(new Visitor(match.Value));

                }
                Console.Write("Количество посителей: ");
                Console.ForegroundColor = (visitors.Count() >= 1 ? ConsoleColor.Green : ConsoleColor.Red);
                Console.WriteLine(visitors.Count());
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Menu.printError();
                Console.WriteLine(e.ToString());
            }
            return visitors;

        }

        /// <summary>
        /// Чтение входных строк 
        /// </summary>
        /// <returns></returns>
        public static string ReadingInputText()
        {
            StringBuilder sb = new();
            string? text;
            while ((text = Console.ReadLine()) != null)
            {
                sb.Append(text);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Метод для чтения данных через файл, путем изменения стандратного потока данных.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ReadJSONText(string filePath) 
        {

                string jsonString = string.Empty;
            try
            {
                using (FileStream fs = new(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new(fs, Encoding.UTF8))
                    {
                        Console.SetIn(sr);
                        jsonString = ReadingInputText();
                    }
                }
                Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            }
            catch (Exception e)
            {   Menu.printError();
                Console.WriteLine(e.ToString());
            }

            return jsonString;
            
        }




    }
}
