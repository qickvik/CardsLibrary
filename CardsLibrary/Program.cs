using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
            }
            catch (ReadingForFileException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidPropertyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Извините, произошла ошибка. В скором времени мы всё исправим!");
                using (StreamWriter writer = new StreamWriter("error_log.txt", true))
                {
                    writer.WriteLine($"Ошибка: {ex.Message}");
                    writer.WriteLine($"Стек вызовов: {ex.StackTrace}");
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(new string('-', 150));
                }
            }
        }
        static Base GetData()
        {
            bool CorrectFileName = false;
            string FileName;
            while (!CorrectFileName)
            {
                try
                {
                    Console.WriteLine("Введите имя файла (или путь к файлу) с расширением, если оно имеется");
                    FileName = Console.ReadLine();
                    CorrectFileName = true;
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                        try
                        {
                            bool isnymeric = int.TryParse(sr.ReadLine(), out int n);
                            if (isnymeric)
                            {
                                List<string> replay = new List<string>();
                                Base decks = new Base();
                                for (int i = 0; i < n; i++)
                                {
                                    string[] str = sr.ReadLine().Split(new char[] { '|' });
                                    if (str[0] == "playing cards")
                                        decks.AddDeck(new Play(str[1], str[2], str[3], str[4], str[5], str[6]));

                                    if (str[0] == "divination cards")
                                        decks.AddDeck(new Divination(str[1], str[2], str[3], str[4], str[5], str[6]));

                                    if (str[0] == "tarot")
                                        decks.AddDeck(new Tarot(str[1], str[2], str[3], str[4], str[5], str[6], str[7], int.Parse(str[8])));
                                    if (replay.Contains(str[1]) == false)
                                        replay.Add(str[1]);
                                    else
                                        throw new ArgumentException();
                                }
                                Console.Write("Данные успешно загружены");
                                Console.WriteLine();
                                return decks;
                            }
                            else
                            {
                                throw new ArgumentException();
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message + " (Файл содержит данные, не подходящие под формат ввода).");
                            return null;
                        }
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Введите корректное имя файла или корректный путь в следующий раз.");
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Не введено имя");
                }
            }
            return null;
        }
        static void GetFile(Base decks)
        {
            try
            {
                if (decks != null)
                {
                    Console.WriteLine("Введите имя для файла, который хотите создать");
                    string FileName = Console.ReadLine();
                    if (!FileName.Contains(".txt"))
                    {
                        FileName = FileName + ".txt";
                        Console.WriteLine("Имя было указано без расширения, поэтому файлу присвоено расширение .txt");
                    }
                    using (StreamWriter sw = new StreamWriter(FileName))
                    {
                        sw.WriteLine(decks.Count());
                        for (int i = 0; i < decks.Count(); i++)
                            sw.WriteLine(decks.Count());
                    }
                    Console.Write("Успешно");
                    Console.WriteLine();
                }
                else
                    throw new NoDataUploadedException();
            }
            catch (NoDataUploadedException)
            {
                Console.WriteLine("Ошибка при выводе данных в файл.");
            }
        }
        static void Writer(Base decks)
        {
            try
            {
                if (decks != null)
                {
                    int count = 1;
                    foreach (var deck in decks)
                    {
                        Console.WriteLine($"{count}. " + deck.ToString());
                        count++;
                    }
                }
                else
                    throw new NoDataUploadedException();
            }
            catch (NoDataUploadedException)
            {
                Console.WriteLine("Ошибка при выводе данных.");
            }
        }
    }
}
