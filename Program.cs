using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите название приложения (notepad или calculator) или 'exit' для выхода:");
        string input;

        while ((input = Console.ReadLine()) != "exit")
        {
            if (input.Equals("notepad", StringComparison.OrdinalIgnoreCase))
            {
                Process notepad = Process.Start("notepad");
                Console.WriteLine("Блокнот открыт. Для его закрытия введите 'kill notepad'.");
            }
            else if (input.Equals("calculator", StringComparison.OrdinalIgnoreCase))
            {
                Process calc = Process.Start("calc");
                Console.WriteLine("Калькулятор открыт. Для его закрытия введите 'kill calculator'.");
            }
            else if (input.StartsWith("kill ", StringComparison.OrdinalIgnoreCase))
            {
                string processToKill = input.Substring(5).Trim();

                if (processToKill.Equals("notepad", StringComparison.OrdinalIgnoreCase))
                {
                    var processes = Process.GetProcessesByName("notepad");
                    foreach (var process in processes)
                    {
                        process.Kill();
                    }
                    Console.WriteLine("Блокнот закрыт.");
                }
                else if (processToKill.Equals("calculator", StringComparison.OrdinalIgnoreCase))
                {
                    var processes = Process.GetProcessesByName("calc");
                    foreach (var process in processes)
                    {
                        process.Kill();
                    }
                    Console.WriteLine("Калькулятор закрыт.");
                }
                else
                {
                    Console.WriteLine("Неизвестный процесс для завершения. Пожалуйста, введите 'kill notepad' или 'kill calculator'.");
                }
            }
            else
            {
                Console.WriteLine("Неизвестное приложение. Пожалуйста, введите 'notepad', 'calculator' или 'exit' для выхода.");
            }

            Console.WriteLine("Введите название приложения (notepad или calculator) или 'exit' для выхода:");
        }
    }
}
