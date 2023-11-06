namespace Task2;

using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Repository<int> intRepository = new Repository<int>();
        intRepository.Add(1);
        intRepository.Add(2);
        intRepository.Add(3);
        intRepository.Add(4);
        intRepository.Add(5);

        Criteria<int> evenNumberCriteria = x => x % 2 == 0;
        List<int> evenNumbers = intRepository.Find(evenNumberCriteria);

        Console.WriteLine("Репозиторії з парними числами:");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
