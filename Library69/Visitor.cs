using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Стурктура представляющая собой объекты из JSON0-файла.
    /// </summary>
    public struct Visitor : IJSONObject
    {
        string id = string.Empty;
        string label = string.Empty;
        string desc = string.Empty;
        string inherits = string.Empty;
        AspectsObject aspects = new AspectsObject(String.Empty);
        string decayto = string.Empty;
        string lifeTime = string.Empty;
        string xtriggers = string.Empty;
        string xexts= string.Empty;
        string icon = string.Empty;
        string audio = string.Empty;
        string comments = string.Empty;


        /// <summary>
        /// Стандратный конструктор.
        /// </summary>
        public Visitor() { }
        /// <summary>
        /// Конструктор принимающий в себя строку данные для парсинга.
        /// </summary>
        /// <param name="name"></param>ё    
        public Visitor(string name) 
        {
            
            Id = name;
            Label = name;
            Desc = name;
            Inherits = name;
            Aspects = name;
            Decayto = name;
            LifeTime = name;
            Xtriggers = name;
            Xexts = name;
            Icon = name;
            Audio = name;
            Comments = name;

        }
        /// <summary>
        /// Возращает значение поля id.
        /// </summary>
        public string Id 
        {
            get
            { 
                return id;

            }
         private set
            {
                string pattern = @"""?\s*id\s*""\s*:\s*""([^""]+)""";
                Regex regex = new Regex(pattern, RegexOptions.Multiline);
                Match match = regex.Match(value);
                id = match.Groups[1].Value;
            }
        }
        /// <summary>
        /// Возращает значение поля label.
        /// </summary>
        public string Label 
        {
            get
            { 
                return "\"" + label + "\"";
            }
            private set
            {
                string pattern = @"""?\s*label\s*""\s*:\s*""([^""]+)""";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                label = match.Groups[1].Value;
            }
        }
        /// <summary>
        /// Возращает значение поля decs.
        /// </summary>
        public string Desc  {
            get
            {
                return "\"" + desc + "\"";
            }
            private set
            {
                string pattern = @"""?\s*desc\s*""\s*:\s*""([^""]+)""";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                desc = match.Groups[1].Value;
            }
        }
        /// <summary>
        /// Возращает значение поля inherits.
        /// </summary>
        public string Inherits {
            get
            {
                return "\"" + inherits + "\"";
            }
            private set
            {
                string pattern = @"""?\s*inherits\s*""\s*:\s*""([^""]+)""";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                inherits = match.Groups[1].Value;

            }
        }
        /// <summary>
        /// Возращает значение поля aspects.
        /// </summary>
        public string Aspects {
            get
            {
                return aspects.ToString();
            }
            private set
            {
                string pattern = @"""aspects""\s*:\s*({[^}]*})";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);
                Match match = regex.Match((value));
                aspects = new AspectsObject(match.Groups[1].Value);

            }
        }
        /// <summary>
        /// Возращает значение поля decayto.
        /// </summary>
        public string Decayto {
            get
            {
                return "\""+ decayto + "\"";
            }
            private set
            {
                string pattern = @"""?\s*decayto\s*""\s*:\s*""([^""]+)""";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                decayto = match.Groups[1].Value;

            }
        }
        /// <summary>
        /// Возращает значение поля lifetime.
        /// </summary>
        public string LifeTime {
            get
            {
                return  lifeTime;
            }
            private set
            {
                string pattern = @"""?\s*lifetime\s*""\s*:\s*(\d+)";
                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                lifeTime = match.Groups[1].Value;

            }
        }
        /// <summary>
        /// Возращает значение поля xtrigers.
        /// </summary>
        public string Xtriggers {
            get
            {
                return xtriggers;
            }
            private set
            {
                string pattern = @"""xtriggers""\s*:\s*(\{(?:[^{}[]|(?<={)|(?=>)|(\[[^\[\]]*\])|(\{[^{}]*\}))*\})";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                xtriggers = match.Groups[1].Value;

            }
        }
        public string Xexts {
            get
            {
                return xexts;
            }
            private set
            {
                string pattern = @"""xexts""\s*:\s*(\{(?:[^{}]|(?<={)|(?=>))*\})";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);
                Match match = regex.Match(value);
                xexts = match.Groups[1].Value;

            }
        }
        /// <summary>
        /// Возращает значение поля icon.
        /// </summary>
        public string Icon
        {
            get
            {
                return "\"" + icon + "\"";
            }
            private set
            {
                string pattern = @"""?\s*icon\s*""\s*:\s*""([^""]+)""";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                icon = match.Groups[1].Value;
            }
        }
        /// <summary>
        /// Возращает значение поля Commnets.
        /// </summary>
        public string Comments
        {
            get
            {
                return "\"" + comments + "\"";
            }
            private set
            {
                string pattern = @"""?\s*comments\s*""\s*:\s*""([^""]+)""";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                comments = match.Groups[1].Value;
            }
        }
        /// <summary>
        /// Возращает значение поля audio.
        /// </summary>
        public string Audio
        {
            get
            {
                return "\"" + audio + "\"";
            }
            private set
            {
                string pattern = @"""?\s*audio\s*""\s*:\s*""([^""]+)""";

                Regex regex = new Regex(pattern, RegexOptions.Multiline);

                Match match = regex.Match(value);
                audio = match.Groups[1].Value;
            }
        }
        /// <summary>
        /// Метод возращающий все поля объекта.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllFields()
        {
            List<string> fields = new();
            foreach (PropertyInfo propertyInfo in GetType().GetProperties())
            {
                 fields.Add(propertyInfo.Name.ToLower());
            }
            return fields;
        }
        /// <summary>
        /// Возращает значение поля по заданному имени.
        /// </summary>
        public string GetField(string fieldName)
        {
            switch (fieldName.ToLower())
            {
                case "id": return $"\"{Id}\"";
                case "label": return $"\"{Label}\"";
                case "desc": return $"\"{Desc}\"";
                case "inherits": return $"\"{Inherits}\"";
                case "aspects": return $"\"{Aspects}\"";
                case "decayto": return $"\"{Decayto}\"";
                case "lifetime": return $"{LifeTime}";
                case "comments": return $"{Comments}";
                case "icon": return $"{Icon}";
                case "audio": return $"{Audio}";
                case "xtriggers": return $"{{xtriggers}}";
                case "xexts": return $"{{xexts}}";
                default:
                    Exception keyNotFoundException = new Exception();
                    throw keyNotFoundException;
            }
        }
        /// <summary>
        /// Устанавливает заданное значение в переданное поле, если такое есть.
        /// </summary>
        public void SetField(string fieldName, string value)
        {
            switch (fieldName.ToLower())
            {
                case "id":id = value; break;
                case "label": label = value; break;
                case "desc": desc = value; break;
                case "inherits": inherits = value; break;
                case "aspects": aspects = new AspectsObject(value); break;
                case "decayto": decayto = value; break;
                case "lifetime": lifeTime = value; break;
                case "xtriggers": xtriggers = value; break;
                case "xexts": xexts = value; break;
                case "comments": comments = value; break;
                case "audio": audio = value; break;
                case "icon": icon = value; break;
                default:
                    Menu.printError();
                    Exception keyNotFoundException = new Exception();
                    throw keyNotFoundException;

            }
        }
        /// <summary>
        /// Преобразует данные в текст.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = $"\t{{{Environment.NewLine}";
            if (!string.IsNullOrEmpty(id)) { output += Environment.NewLine + $"{new string(' ',6)}\"id\" : \"{Id}\""; }
            if (!string.IsNullOrEmpty(label) ) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"label\" : {Label}"; }
            if (!string.IsNullOrEmpty(desc)) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"desc\" : {Desc}"; }
            if (!string.IsNullOrEmpty(inherits)) { output += ","+ Environment.NewLine + $"{new string(' ', 6)}\"inherits\" : {Inherits}"; }
            if (!string.IsNullOrEmpty(Aspects)) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"aspects\" : {Aspects.ToString()}"; }
            if (!string.IsNullOrEmpty(decayto)) { output +=  "," + Environment.NewLine + $"{new string(' ', 6)}\"Decayto\" : {Decayto}"; }
            if (!string.IsNullOrEmpty(lifeTime)) { output  += "," + Environment.NewLine + $"{new string(' ', 6)}\"lifetime\" : {LifeTime}"; }
            if (!string.IsNullOrEmpty(icon)) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"icon\" : {Icon}"; }
            if (!string.IsNullOrEmpty(audio)) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"audio\" : {Audio}"; }
            if (!string.IsNullOrEmpty(comments)) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"comments\" : {Comments}"; }
            if (!string.IsNullOrEmpty(xtriggers)) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"xtriggers\" : {xtriggers}"; }
            if (!string.IsNullOrEmpty(xexts)) { output += "," + Environment.NewLine + $"{new string(' ', 6)}\"xexts\" : {Xexts}"; }
            output += Environment.NewLine +  new string(' ',6) +"}";
            return output ;
        }
        /// <summary>
        /// Проверяет тип данных свойства на реализуцию IJSONObject  
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool IsNestedProperty(PropertyInfo propertyInfo)
        {
            if (propertyInfo is IJSONObject)
            {
                return true;
            }
            else return  false;
        }
        public List<string> GetNotNestededFields()
        {
            Visitor visitor = this;
            List<string> fields = new List<string>();
            foreach (PropertyInfo propertyInfo in visitor.GetType().GetProperties())
            {
                if (!Visitor.IsNestedProperty(propertyInfo))
                {
                    fields.Add(propertyInfo.Name);
                }
            }
            return fields ;
        }
    }
}
