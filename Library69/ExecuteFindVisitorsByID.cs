using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс реализующий поис посетителя по ID
    /// </summary>
    public class ExecuteFindVisitorsByID
    {
        /// <summary>
        /// Метод по заданному айди ищет посетителя и выводит главную информацию об посетителе.
        /// </summary>
        /// <param name="visitors"></param>
        public void FindVisitorsByID(ref List<Visitor> visitors)
        {
            try
            {
                if (visitors.Count > 0)
                {
                    bool found = false;
                    Console.Write("Введите ID посетителя: ");
                    string? id = Console.ReadLine();
                    if (id != null && id.Length != 0)
                    {
                        foreach (var visitor in visitors)
                        {
                            if (visitor.Id.Trim('"') == id)
                            {
                                Console.WriteLine($"Персонаж : {visitor.Label} ({visitor.Id}){Environment.NewLine}Описание: {visitor.Desc}{Environment.NewLine}Aспекты:{visitor.Aspects.ToString()}".Replace("\"", ""));

                                found = true;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Такого посетилея не найдено(( ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введены некореткнын данные");

                    }
                }
                else
                {
                    Menu.printError(); Console.WriteLine("Сначала загрузите данные!!!"); Console.WriteLine("Нажмите чтобы продолжить..."); Console.ReadKey(); return;
                }
                Console.WriteLine("Нажмите чтобы продолжить");
                Console.ReadKey();
            }
            catch (Exception e) 
            {
                Menu.printError();
                Console.WriteLine(e.ToString());
                Console.WriteLine("Нажмите чтобы продолжить");
                Console.ReadKey();
            }
        }
    }
}
