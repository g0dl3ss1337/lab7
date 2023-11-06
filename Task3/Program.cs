using System;
using System.Text;

namespace Task3;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Приклад використання
        var cache = new FunctionCache<string, int>(CalculateExpensiveResult);

        int result1 = cache.GetResult("key1", TimeSpan.FromMinutes(5));
        Console.WriteLine("Результат 1: " + result1);

        int result2 = cache.GetResult("key2", TimeSpan.FromMinutes(5));
        Console.WriteLine("Результат 2: " + result2);

        int result3 = cache.GetResult("key1", TimeSpan.FromMinutes(5)); // Цей виклик використовує кеш
        Console.WriteLine("Результат 3: " + result3);

        int result4 = cache.GetResult("key2", TimeSpan.FromMinutes(1)); // Резульатт для key2 зберігається в кеші лише 1 хвилину
        Console.WriteLine("Результат 4: " + result4);
    }

    static int CalculateExpensiveResult(string key)
    {
        Console.WriteLine("Розрахунок результату для ключа: " + key);
        // Тут може бути складний розрахунок
        return key.Length;
    }
}
