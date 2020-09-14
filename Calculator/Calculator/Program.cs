using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Eneter First");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Eneter operator");
            string @operator = Console.ReadLine();

            Console.WriteLine("Eneter Second");
            int b = int.Parse(Console.ReadLine());

            switch (@operator)
            {
                case "+": Console.WriteLine($"Result {a + b}"); break;
                case "-": Console.WriteLine($"Result {a - b}"); break;
                case "*": Console.WriteLine($"Result {a * b}"); break;
                case "/": Console.WriteLine($"Result {a / b}"); break;
                default: throw new NotSupportedException("Operation has not defined!");
            }
            Console.ReadKey();
        }
    }
}
