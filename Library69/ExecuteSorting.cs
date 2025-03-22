using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс реализующий сортировку данных.
    /// </summary>
    public class ExecuteSorting : IExecutionOfNestedMenuItems
    {
        public string[] menu => FieldMenu.SortMenu;//Пункты меню

        /// <summary>
        /// Выход в основное меню.
        /// </summary>
        public void Exit()
        {
            return;
        }

        /// <summary>
        /// Сортировка данных по заданному полю по убыванию.
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="data"></param>
        public void FirstTask(ref List<Visitor> visitors, ref string data)//Убывание
        {
            try
            {
                List<string> fields = visitors[0].GetNotNestededFields();
                for (int i = 0; i < fields.Count; i++)
                {

                    Console.WriteLine($"{i + 1}. {fields[i]}");
                }
                Console.Write("Введите номер поля: ");
                string? filedNumber = Console.ReadLine();
                if (filedNumber is not null && int.TryParse(filedNumber, out int numberOfTheSortingField) && numberOfTheSortingField > 0 && numberOfTheSortingField <= fields.Count)
                {
                    if (int.TryParse(visitors[0].GetField(fields[int.Parse(filedNumber) - 1]), out int _))
                    {
                        visitors = visitors.OrderBy(v => int.Parse(v.GetField(fields[int.Parse(filedNumber) - 1]))).Reverse().ToList();
                    }
                }
                else visitors = visitors.OrderBy(v => v.GetField(fields[int.Parse(filedNumber) - 1])).Reverse().ToList();
                Console.WriteLine("Нажмите чтобы продолжить");
                Console.ReadKey();
            }
             catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            Console.WriteLine("Нажмите чтобы продолжить");
            Console.ReadKey();

        }
        /// <summary>
        /// Сортировка данных по заданному полю по возрастанию.
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="data"></param>
        public void SecondTask(ref List<Visitor> visitors, ref string data)// возрастание
        {
            try
            {
                List<string> fields = visitors[0].GetNotNestededFields();
                for (int i = 0; i < fields.Count; i++)
                {

                    Console.WriteLine($"{i + 1}. {fields[i]}");
                }
                Console.Write("Введите номер поля: ");
                string? filedNumber = Console.ReadLine();
                if (filedNumber is not null && int.TryParse(filedNumber, out int numberOfTheSortingField) && numberOfTheSortingField > 0 && numberOfTheSortingField <= fields.Count)
                {
                    if (int.TryParse(visitors[0].GetField(fields[int.Parse(filedNumber) - 1]), out int _))
                    {
                        visitors = visitors.OrderBy(v => int.Parse(v.GetField(fields[int.Parse(filedNumber) - 1]))).ToList();
                    }
                }
                else visitors = visitors.OrderBy(v => v.GetField(fields[int.Parse(filedNumber) - 1])).ToList();
            }
            catch (Exception e)
            {
                Menu.printError();
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Нажмите чтобы продолжить");
            Console.ReadKey();
        }
    }
}
