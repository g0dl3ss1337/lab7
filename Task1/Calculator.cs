using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Calculator<T>
    {
        public delegate T ArithmeticOperation(T x, T y);

        public ArithmeticOperation Addition { get; } = (x, y) => (dynamic)x + y;
        public ArithmeticOperation Subtraction { get; } = (x, y) => (dynamic)x - y;
        public ArithmeticOperation Multiplication { get; } = (x, y) => (dynamic)x * y;
        public ArithmeticOperation Division { get; } = (x, y) => (dynamic)x / y;

        public T PerformOperation(T x, T y, ArithmeticOperation operation)
        {
            return operation(x, y);
        }
    }
}
