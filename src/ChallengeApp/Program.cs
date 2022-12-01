using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee("Karolina");
            employee.AddGrade(34.4);


            var stat = employee.GetStatistics();

            Console.WriteLine($"The average is: {stat.Average}");


            if (args.Length > 0)
            {
                Console.WriteLine("Hello " + args[0]);
            }
            else
            {
                Console.WriteLine("Hello");
            }
        }

    }
}

