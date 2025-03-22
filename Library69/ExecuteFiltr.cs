using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Класс реализующий задачу фильтрации данных.
    /// </summary>
    /// <param name="visitors"></param>
    public class ExecuteFiltr 
    {
       /// <summary>
       /// Метод фильтрующий данные.
       /// </summary>
       /// <param name="visitors"></param>
        public void DataFilter(ref List<Visitor> visitors) 
        {
            try
            {
                if (visitors.Count > 0)
                {
                    List<string> fields = visitors[0].GetNotNestededFields();
                    for (int i = 0; i < fields.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {fields[i]}");
                    }
                    Console.Write("Введите номер поля: ");
                    string? filter = Console.ReadLine();
                    if (int.TryParse(filter, out int filterNumber) && filterNumber > 0 && filterNumber <= fields.Count)
                    {
                        List<string> values = new();
                        Console.WriteLine("Для завершения введите пустую строку");
                        while (true)
                        {
                            Console.Write("Введите значение: ");
                            string? value = Console.ReadLine();

                            if (value is not null && value.Length != 0)
                            {
                                values.Add(value);
                            }
                            else
                            {
                                Console.WriteLine("Значения приняты");
                                break;
                            }


                        }
                        List<Visitor> newVis = new List<Visitor>();
                        foreach (Visitor v in visitors)
                        {
                            bool flag = false;
                            foreach (string f in values)
                            {
                                if (v.GetField(fields[filterNumber - 1]).Trim('"').Trim().Trim('"') == f.Trim('"').Trim().Trim('"'))

                                {
                                    flag = true;
                                }

                            }
                            if (flag)
                            {
                                newVis.Add(v);
                            }

                        }
                        visitors = new();
                        if (newVis.Count > 0)
                        {
                            foreach (Visitor v in newVis)
                            {
                                visitors.Add(v);
                            }
                        }

                        Console.WriteLine($"Количество посититлей после фильтрации по полю {fields[filterNumber - 1]} со значениями [{String.Join(' ', values)}] :");
                        Console.ForegroundColor = (visitors.Count() >= 1 ? ConsoleColor.Green : ConsoleColor.Red);
                        Console.WriteLine(visitors.Count());
                        Console.ResetColor();


                    }
                    else
                    {
                        Console.WriteLine("Введен некорректный номер поля.");
                    }
                    Console.WriteLine("Нажмите для проджолжения");
                    Console.ReadKey();
                }
                else
                {
                    Menu.printError(); Console.WriteLine("Сначала загрузите данные!!!"); Console.WriteLine("Нажмите чтобы продолжить..."); Console.ReadKey(); return;
                }
            }
            catch (Exception e)  
            {
                Menu.printError();
                Console.WriteLine(e.ToString());
                Console.WriteLine("Нажмите для проджолжения");
                Console.ReadKey();
            }
            
        } 
    }
}
