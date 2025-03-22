using System.Collections.Generic;

namespace Library69
{
    /// <summary>
    /// Класс реализующий вывод консольного меню.
    /// </summary>
    public class Menu
    {
        public static void printError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR:");
            Console.ResetColor();
        }
        /// <summary>
        /// Вывод пукнтов меню, с выделением строки выбора.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="index"></param>
        public void PrintMenu(string[] fields, int index)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);//Курсор устанавливаем в левом верхнем углу.
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("===============MENU===============");
            Console.ResetColor();
            for (int i = 0; i < fields.Length; i++)
            {
                if (i == index)//В строке на которой курсор меняем увет текста на черный а задний фон на белый, что выделяет строку
                {
                    Console.Write("->");
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                Console.WriteLine($"{fields[i]}");
                Console.ResetColor();

            }
                        Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("===============END===============");
            Console.ResetColor();
            
        }

        /// <summary>
        /// Метод выводит на экран пукнты меню и реализует выбор их путем стрелочек и enter.
        /// </summary>
        /// <param name="fragments">Объект с которым мы работаем</param>
        /// <param name="index">Номер пункта меню</param>
        /// <param name="menu">Объект класса в котором находится метод для вывода пунктов меню</param>
        /// <param name="inputFilePath">Файл для чтения</param>
        /// <param name="outputFilePath">Файл для вывода</param>
        public void LaunchingMainMenu(int index, string[] menu, ref List<Visitor> visitors, ref string data)
        {
            while (true)
            {
                PrintMenu(menu, index);
                Console.Write("Количество поситителей: ");
                Console.ForegroundColor =( visitors.Count>=1 ? ConsoleColor.Green : ConsoleColor.Red);
                Console.WriteLine(visitors.Count());
                Console.ResetColor();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menu.Length-1)
                            index++;
                        else
                        {
                            index = 0;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                        {
                            index = menu.Length-1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (index + 1)
                        {
                            case 1:
                                int nestedindex = 0;
                                LaunchingSecondMenu(nestedindex, new ExecuteInputData(), ref visitors, ref data);
                                break;
                            case 2:
                                nestedindex = 0;
                                ExecuteFiltr executeFiltr = new ExecuteFiltr();
                                executeFiltr.DataFilter(ref visitors);
                                break;
                            case 3:
                                nestedindex = 0;
                                LaunchingSecondMenu(nestedindex, new ExecuteSorting(), ref visitors, ref data);
                                break;
                            case 4:
                                nestedindex = 0;
                                LaunchingSecondMenu(nestedindex, new ExecuteExcelDoc(), ref visitors, ref data);
                                break;
                            case 5:
                                nestedindex = 0;
                                ExecuteFindVisitorsByID idFounder = new ExecuteFindVisitorsByID();
                                idFounder.FindVisitorsByID(ref visitors);
                                break;
                            case 6:
                                nestedindex = 0;
                                LaunchingSecondMenu(nestedindex, new ExecuteOutputData(), ref visitors, ref data);
                                break;
                            case 7:
                                //"Записать данные в файл"                                
                                return;

                            
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Выводит подменю и реализует выбор пунктов подменю путем стрелочки и enter.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <param name="visitors"></param>
        /// <param name="data"></param>
        public void LaunchingSecondMenu(int index,IExecutionOfNestedMenuItems item,ref List<Visitor> visitors,ref string data)
        {
            string[] menu = item.menu;
            
            while (true)
            {
                PrintMenu(menu, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menu.Length - 1)
                            index++;
                        else
                        {
                            index = 0;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                        {
                            index = menu.Length - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (index + 1)
                        {
                            case 1:
                                item.FirstTask(ref visitors,ref data);
                                break;
                            case 2:
                                item.SecondTask(ref visitors,ref data);
                                break;
                            case 3:
                                item.Exit();
                                return;
                        }
                        break;
                }
            }
        }



    }

}
