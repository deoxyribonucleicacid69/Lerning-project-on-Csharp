using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс реализующий вывода данных
    /// </summary>
    public class ExecuteOutputData : IExecutionOfNestedMenuItems
    {
        public string[] menu => FieldMenu.OutputMenu; //Пункты меню.

        /// <summary>
        /// Возврат в основное меню.
        /// </summary>
        public void Exit()
        {
            return;
        }
        /// <summary>
        /// Вывод данных в консоль.
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="data"></param>
        public void FirstTask(ref List<Visitor> visitors, ref string data)
        {
            try
            {
                int count = 0;
                Console.Write("Количество элементов: ");
                Console.WriteLine(visitors.Count);
                foreach (var visitor in visitors)
                {
                    count++;
                    if (count == visitors.Count)
                    {

                        Console.WriteLine(visitor.ToString() + Environment.NewLine + "}");

                    }
                    else
                    {
                        Console.WriteLine(visitor.ToString() + ",");

                    }
                }
            }
            catch (Exception e)
            {
                Menu.printError();
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Нажмите чтобы продолжить");
            Console.ReadKey();
        }
        /// <summary>
        /// Вывод данных в файл.
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="data"></param>
        public void SecondTask(ref List<Visitor> visitors, ref string data)
        {
            if (visitors.Count>0)
            {
                Console.Write("Напишите путь до файла или имя: ");
                string outputFilePath = Console.ReadLine();
                if (outputFilePath is not null)
                {
                    try
                    {
                        using (FileStream fs = new(outputFilePath, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter sw = new(fs, Encoding.UTF8))
                            {
                                Console.SetOut(sw);
                                int count = 0;
                                Console.WriteLine($"{{{Environment.NewLine}\t\"elements\": [{Environment.NewLine}");
                                foreach (var visitor in visitors)
                                {
                                    count++;
                                    Console.WriteLine(visitor.ToString());
                                    if (count != visitors.Count)
                                    {
                                        Console.WriteLine(",");
                                    }
                                }
                                Console.WriteLine($"{Environment.NewLine}\t]{Environment.NewLine}}}");
                            }
                            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
                            Console.OutputEncoding = Encoding.UTF8;
                        }
                        Console.WriteLine("Данные записаны!!!");
                        
                    }
                    catch (Exception ex)
                    {
                        Menu.printError();
                        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            Console.WriteLine("Нажмите для проджолжения");
            Console.ReadKey();
        }
    }
}
