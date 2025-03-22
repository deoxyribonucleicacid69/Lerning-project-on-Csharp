namespace Library69
{
    /// <summary>
    /// Класс хранящий в себе все пунты основного меню и понкты подменю.
    /// </summary>
    public static class FieldMenu
    {
        private readonly static string[] mainMenu = { "Ввести данные", "Отфильтровать данный", "Отсортировать данные", "Отчет в EXCEL - таблицу", "Вывести ифнормацию по ID", "Вывести данные", "Выход" };
        private readonly static string[] inputMenu =  { "Ввести данные через консоль", "Ввести данные через файл", "Назад" };
        private readonly static string[] sortMenu = { "По убыванию", "По возрастанию" , "Назад" };
        private readonly static string[] outputMenu = { "Вывести данные в консоль", "Вывести данные в файл", "Назад" };
        private readonly static string[] excelMenu = { "Ввести данные в EXCEL-таблицу", "Загрузить данные в EXCEl-таблицу", "Назад" };
        /// <summary>
        /// Возращает основное меню
        /// </summary>
        public static string[] MainMenu
        {
            get { return mainMenu; }
        }
        /// <summary>
        /// Возращает подменю ввода данных
        /// </summary>
        public static string[] InputMenu
        {
            get { return inputMenu; }
        }
        /// <summary>
        /// Возращает подменю сортировки данных
        /// </summary>
        public static string[] SortMenu
        {
            get { return sortMenu; }
        }
        /// <summary>
        /// Возращает подменю вывода данных
        /// </summary>
        public static string[] OutputMenu
        {
            get { return outputMenu; }
        }
        /// <summary>
        /// Возращает подменю подменю работы с экселем.
        /// </summary>
        public static string[] ExcelMenu
        {
            get { return excelMenu; }
        }

    }

}
