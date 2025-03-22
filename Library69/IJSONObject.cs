using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

///Данные коментарии написал DeepSeek url:https://chat.deepseek.com/
namespace Library69
{/// <summary>
 /// Интерфейс для работы с объектом, который представляет JSON-структуру.
 /// </summary>
    public interface IJSONObject
    {
        /// <summary>
        /// Возвращает перечисление всех полей (ключей) в JSON-объекте.
        /// </summary>
        /// <returns>
        /// Перечисление строк, представляющих имена полей (ключей) в JSON-объекте.
        /// </returns>
        IEnumerable<string> GetAllFields();

        /// <summary>
        /// Возвращает значение поля по его имени.
        /// </summary>
        /// <param name="fieldName">Имя поля (ключа), значение которого требуется получить.</param>
        /// <returns>
        /// Значение поля в виде строки. Если поле не найдено, возвращается <c>null</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Выбрасывается, если <paramref name="fieldName"/> равен <c>null</c>.
        /// </exception>
        string GetField(string fieldName);

        /// <summary>
        /// Устанавливает значение для указанного поля в JSON-объекте.
        /// </summary>
        /// <param name="fieldName">Имя поля (ключа), значение которого требуется установить.</param>
        /// <param name="value">Значение, которое будет присвоено полю.</param>
        /// <exception cref="ArgumentNullException">
        /// Выбрасывается, если <paramref name="fieldName"/> или <paramref name="value"/> равен <c>null</c>.
        /// </exception>
        void SetField(string fieldName, string value);
    }
}
