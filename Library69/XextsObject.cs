using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс реализующий поле XextsObject
    /// </summary>
    public class XextsObject : IJSONObject
    {
        public XextsObject(string name) { }
        /// <summary>
        /// Свойство возращающий словарь где : ключ - имя поля, значение по ключу - значение поля. 
        /// </summary>
        public Dictionary<string, string> Xexts { get; private set; }
        /// <summary>
        /// Возращает списко всех полей в структуре.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllFields()
        {
            return Xexts.Keys;
        }
        /// <summary>
        /// Возращает значение заднного поля.
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
        /// Устанавливает переданное значение в поля с переданным именем если такое поле есть.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public void SetField(string fieldName, string value)
        {
            bool flag = false;
            foreach (var field in GetAllFields())
            {
                if (field.ToLower() == fieldName.ToLower())
                {
                    Xexts[fieldName.ToLower()] = value;
                    flag = true;
                }
            }
            if (!flag)
            {
                Exception keyNotFoundException = new Exception();
                throw keyNotFoundException;
            }
        }
    }
}
