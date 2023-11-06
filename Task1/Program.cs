using System.Text;

namespace Task1;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Calculator<int> intCalculator = new Calculator<int>();
        Console.WriteLine("int калькулятор:");
        Console.WriteLine($"+ : {intCalculator.PerformOperation(5, 3, intCalculator.Addition)}");
        Console.WriteLine($"- : {intCalculator.PerformOperation(5, 3, intCalculator.Subtraction)}");
        Console.WriteLine($"* : {intCalculator.PerformOperation(5, 3, intCalculator.Multiplication)}");
        Console.WriteLine($"/ : {intCalculator.PerformOperation(6, 2, intCalculator.Division)}");

        Calculator<double> doubleCalculator = new Calculator<double>();
        Console.WriteLine("\ndouble калькулятор:");
        Console.WriteLine($"+ : {doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Addition)}");
        Console.WriteLine($"- : {doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Subtraction)}");
        Console.WriteLine($"* : {doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Multiplication)}");
        Console.WriteLine($"/ : {doubleCalculator.PerformOperation(6.0, 2.0, doubleCalculator.Division)}");
    }
}