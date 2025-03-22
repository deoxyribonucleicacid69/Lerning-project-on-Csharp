using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс представляющий вложенную структуру Aspects
    /// </summary>
    public class AspectsObject : IJSONObject
    {

        private Dictionary<string, string> Aspects = new();
        /// <summary>
        /// Конструктор, с данными для структуры Aspects.
        /// </summary>
        /// <param name="name"></param>
        public AspectsObject(string name)
        {
            string pattern = @"""([^""]+)"":\s*(\d+)";
            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            MatchCollection matches = Regex.Matches(name, pattern, RegexOptions.Singleline);
            foreach (Match match in matches)
            {
                Aspects[match.Groups[1].Value] = match.Groups[2].Value;
            }

        }
        /// <summary>
        /// Возращает все поля объекта.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllFields()
        {
            return Aspects.Keys;
        }
        /// <summary>
        /// Получает значение заданного поля, если такого нет то "null".
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public string GetField(string fieldName)
        {
            foreach (var field in GetAllFields())
            {
                if (field.ToLower() == fieldName.ToLower())
                {
                    return field.ToLower();
                }
            }
            return "null";
        }
        /// <summary>
        /// Устанавливает переданное значение в поле с заданным именем если такое есть.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void SetField(string fieldName, string value)
        {
            bool flag = false;
            if (!int.TryParse(value, out int newValue))
            {
                throw new Exception("Введене некореткное значение для поля!!!");
            }
            foreach (var field in GetAllFields())
            {
                if (field.ToLower() == fieldName.ToLower())
                {
                    Aspects[fieldName.ToLower()] = value;
                    flag = true;
                }
            }
            if (!flag)
            {
                Exception keyNotFoundException = new Exception();
                throw keyNotFoundException;
            }
            
        }
        /// <summary>
        /// Представляет информацию в виде текста.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int count = 0;
            string str = String.Empty;
            str += "{";
            foreach (var key in Aspects.Keys)
            {
                count++;
                str += $"{Environment.NewLine}\t\t\"{key}\" : {Aspects[key]}";
                if (count != Aspects.Keys.Count) { str += ","; }
            }
            str += $"{Environment.NewLine}{new string(' ',6)}}}";
            return str;

        }
    }
}
