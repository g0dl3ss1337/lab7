using System;
using System.Text;

namespace Task4;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(ExecuteTask);
        string input;

        do
        {
            Console.WriteLine("Введіть завдання (або 'q' для виходу): ");
            input = Console.ReadLine();

            if (input != "q")
            {
                Console.WriteLine("Введіть пріоритет: ");
                if (int.TryParse(Console.ReadLine(), out int priority))
                {
                    scheduler.AddTask(input, priority);
                }
            }

        } while (input != "q");

        while (scheduler.Count > 0)
        {
            scheduler.ExecuteNext();
        }
    }

    static void ExecuteTask(string task)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine($"Виконання завдання: {task}");
    }
}
