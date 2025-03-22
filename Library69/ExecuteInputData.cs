using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс для реализации ввода информации
    /// </summary>
    public class ExecuteInputData : IExecutionOfNestedMenuItems
    {
        public string[] menu => FieldMenu.InputMenu;//Пункты меню

        /// <summary>
        /// Возврат в основное меню
        /// </summary>
        public void Exit()
        {
            return;
        }
        /// <summary>
        /// Ввод данных через консоль в формате JSON файла.
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="filepath"></param>
        public void FirstTask(ref List<Visitor> visitors, ref string filepath)
        {
            try
            {
                visitors = new();
                JSONParser parser = new JSONParser();
                Console.Write("Введите данные: ");
                string sb = JSONParser.ReadingInputText();
                try
                {
                    visitors = parser.JSONParsing(sb, ref visitors);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Menu.printError();
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Нажмите для проджолжения");
            Console.ReadKey();
        }



        /// <summary>
        /// Ввод информации через файл
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="filePath"></param>
        public void SecondTask(ref List<Visitor> visitors,ref string filePath)
        {
            try
            {
                visitors = new();
                Console.Write("Введите имя файла:");
                filePath = Console.ReadLine();
                JSONParser parser = new JSONParser();
                string data = parser.ReadJSONText(filePath);
                visitors = parser.JSONParsing(data, ref visitors);
                
            }
            catch (Exception ex)
            {
                Menu.printError();
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("нажмите чтобы продолжить");
            Console.ReadKey();
        }
    }
}
