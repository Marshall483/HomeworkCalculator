using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkCalc
{
    class Input
    {

        public static int GetValue() => int.Parse(Console.ReadLine());
        public static string GetOperator() => Console.ReadLine();

        public static string RequestOperator()
        {
            Console.WriteLine("Now write operation...");
            return GetOperator();
        }


        public static int RequestValue()
        {
            Console.WriteLine("Enter the value...");
            return GetValue();
        }


    }
}
