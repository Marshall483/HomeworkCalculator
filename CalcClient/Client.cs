using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingApp
{
    class Client
    {
        // 2+3 -> first=2$second=3@action=add


        static string _url = "https://localhost:44344/calculate?";


        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            string action = Console.ReadLine();
            double second = double.Parse(Console.ReadLine());

            Connector connector = new Connector(_url);
            Console.WriteLine(connector.Solve(first, action, second).Result);


            Console.ReadKey();
        }
    }
}
