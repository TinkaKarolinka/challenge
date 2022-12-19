using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)

        {
            var employee = new Employee("Karolina");

            while (true)
            {
                Console.WriteLine($"Witaj! Dodajesz ocenę dla pracownika '{employee.Name}'");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    employee.AddGrade(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Aby wyjść i wyświetlić statystyki dla pracownika o imieniu {employee.Name} wciśnij 'q'.");
                }
            }
            var stats = employee.GetStatistics();
            Console.WriteLine($"Najwyższa ocena: {stats.High:N2}");
            Console.WriteLine($"Najniższa ocena: {stats.Low:N2}");
            Console.WriteLine($"Średnia ocen: {stats.Average:N2}");
        }
    }

}