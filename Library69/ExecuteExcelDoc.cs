using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OfficeOpenXml;

namespace Library69
{
    public class ExecuteExcelDoc : IExecutionOfNestedMenuItems
    {
        public string[] menu => FieldMenu.ExcelMenu;
        /// <summary>
        /// Выход из под меню
        /// </summary>
        public void Exit()
        {
            return;
        }
        /// <summary>
        /// Метод загружающий данные в файл.
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="data1"></param>
        public void FirstTask(ref List<Visitor> visitors, ref string data1)
        {
            if (visitors.Count == 0) { Menu.printError(); Console.WriteLine("Сначала загрузите данные!!!"); Console.WriteLine("Нажмите чтобы продолжить..."); Console.ReadKey();return; }
            else
            {
                try
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Visitors");

                        worksheet.Cells[1, 1].Value = "ID";
                        worksheet.Cells[1, 2].Value = "Label";
                        worksheet.Cells[1, 3].Value = "Description";
                        worksheet.Cells[1, 4].Value = "Aspects";
                        worksheet.Cells[1, 5].Value = "DecayTo";
                        worksheet.Cells[1, 6].Value = "Lifetime";
                        worksheet.Cells[1, 7].Value = "Xtriggers";
                        worksheet.Cells[1, 8].Value = "Xexts";
                        worksheet.Cells[1, 9].Value = "Audio";
                        worksheet.Cells[1, 10].Value = "Comments";
                        worksheet.Cells[1, 11].Value = "Icon";

                        using (var range = worksheet.Cells[1, 1, 1, 11])
                        {
                            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            range.Style.Font.Bold = true;
                        }

                        int row = 2;
                        int maxRow = 0;
                        foreach (var visitor in visitors)
                        {
                            worksheet.Cells[row, 1].Value = visitor.Id;
                            worksheet.Cells[row, 2].Value = visitor.Label;
                            worksheet.Cells[row, 3].Value = visitor.Desc;
                            worksheet.Cells[row, 5].Value = visitor.Decayto;
                            worksheet.Cells[row, 6].Value = visitor.LifeTime;
                            worksheet.Cells[row, 9].Value = visitor.Audio;
                            worksheet.Cells[row, 10].Value = visitor.Comments;
                            worksheet.Cells[row, 11].Value = visitor.Icon;
                            int newRow = row - 1 ;
                            string[] Aspects = visitor.Aspects.Replace(" ","").Replace(":", " : ").Replace("{", " { ").Replace("}", " } ").Replace(",", " , ").Replace(",", " , ").Replace("[", " [ ").Replace("]", " ] ").Replace("  "," ").Split(' ');
                            string[] Xtriggers = visitor.Xtriggers.Replace(" ", "").Replace(":", " : ").Replace("{", " { ").Replace("}", " } ").Replace(",", " , ").Replace(",", " , ").Replace("[", " [ ").Replace("]", " ] ").Replace("  ", " ").Split(' ');
                            string[] Xexts = visitor.Xexts.Replace(" ", "").Replace("{", " { ").Replace("}", " } ").Replace(",", " , ").Replace(",", " , ").Replace("[", " [ ").Replace("]", " ] ").Replace("  ", " ").Split(' ');
                            foreach (string field in Aspects)
                            {
                                worksheet.Cells[newRow+1, 4].Value = field;
                                newRow++;
                            }
                            maxRow = Math.Max(row,maxRow);
                            maxRow = Math.Max(newRow, maxRow);
                            newRow = row;
                            foreach (string field in Xtriggers)
                            {
                                worksheet.Cells[newRow, 7].Value = field;
                                newRow++;
                            }
                            maxRow = Math.Max(row, maxRow);
                            maxRow = Math.Max(newRow, maxRow);
                            newRow = row;
                            foreach (string field in Xexts)
                            {
                                worksheet.Cells[newRow, 8].Value = field;
                                newRow++;
                            }
                            maxRow = Math.Max(row, maxRow);
                            maxRow = Math.Max(newRow, maxRow);
                            row = maxRow;
                        }

                        Console.Write("Введите имя файла: ");
                        string outputNameFile = Console.ReadLine() ?? "output.xlsx";
                        package.SaveAs(new FileInfo(outputNameFile));
                    }
                }
                catch (Exception e)
                {
                    Menu.printError();
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Нажмите для проджолжения");
                    Console.ReadKey();
                }
                Console.WriteLine("Нажмите кнопку для продолжения...");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            }
        }

        /// <summary>
        /// Метод загружающий из файла данные.
        /// </summary>
        /// <param name="visitors"></param>
        /// <param name="data"></param>
        public void SecondTask(ref List<Visitor> visitors, ref string data)
        {
            int count = visitors.Count;
            visitors.Clear();
            string excelFilePath = Console.ReadLine();
            if (string.IsNullOrEmpty(excelFilePath))
            {
                Console.WriteLine("Введен некоректный имя файла");
                Console.WriteLine("Нажмите кнопку для продолжения...");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                return;
            }
            try
            {
                
                using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int newRow = 0;
                    int maxRow = 0;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            string aspect = string.Empty;
                            string xtriggers = string.Empty;
                            string xexts = string.Empty;
                            Visitor visitor = new Visitor();
                            visitor.SetField("id", worksheet.Cells[row, 1].Text.Replace("\"", ""));
                            visitor.SetField("label", worksheet.Cells[row, 2].Text.Replace("\"",""));
                            visitor.SetField("desc", worksheet.Cells[row, 3].Text.Replace("\"", ""));
                            visitor.SetField("decayto", worksheet.Cells[row, 5].Text.Replace("\"", ""));
                            visitor.SetField("lifetime", worksheet.Cells[row, 6].Text.Replace("\"", ""));
                            visitor.SetField("audio", worksheet.Cells[row, 9].Text.Replace("\"", ""));
                            visitor.SetField("comments", worksheet.Cells[row, 10].Text.Replace("\"", ""));
                            visitor.SetField("icon", worksheet.Cells[row, 11].Text.Replace("\"", ""));
                            newRow = row + 1;
                            while (worksheet.Cells[newRow, 1].Text.Length == 0)
                            {

                                    aspect += worksheet.Cells[newRow, 4].Text;
                                    newRow++;
                                if (newRow==rowCount)
                                {
                                    break;
                                }
                                

                            }
                            maxRow = Math.Max(maxRow, row);
                            maxRow = Math.Max(maxRow, newRow);
                            newRow = row + 1;
                            while (worksheet.Cells[newRow, 1].Text.Length == 0)
                            {
                                    xtriggers += worksheet.Cells[newRow, 7].Text;
                                    newRow++;
                                if (newRow == rowCount)
                                {
                                    break;
                                }
                            }
                            maxRow = Math.Max(maxRow, row);
                            maxRow = Math.Max(maxRow, newRow);
                            newRow = row + 1;
                            while (worksheet.Cells[newRow, 1].Text.Length == 0)
                            {
                                    xexts += worksheet.Cells[newRow, 8].Text;
                                    newRow++;
                                if (newRow == rowCount)
                                {
                                    break;
                                }
                            }
                            maxRow = Math.Max(maxRow, row);
                            maxRow = Math.Max(maxRow, newRow);
                            row = maxRow-1;
                            visitor.SetField("xtriggers", xtriggers);
                            visitor.SetField("aspects", aspect);
                            visitor.SetField("xexts", xexts);
                            visitors.Add(visitor);
                        }
                        catch (ArgumentException)
                        {

                            break;
                        }

                    }
                }
                Console.WriteLine("Нажмите чтобы продолжить...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Menu.printError();
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Нажмите чтобы продолжить...");
                Console.ReadKey();
            }
            
        }
    }
}
