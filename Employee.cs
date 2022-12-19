using System;
using System.Collections.Generic;
namespace ChallengeApp
{
    public class Employee
    {
        public List<double> grades = new List<double>();

        public Employee(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        public void ChangeName(string newName)
        {
            bool ChangeName = true;

            foreach (var a in newName)
            {
                if (char.IsDigit(a))
                {
                    ChangeName = false;
                    Console.WriteLine($"We wpisanej frazie {newName} znajduje się niedozwolony znak.");
                    break;
                }
            }
            if (ChangeName)
            {
                this.Name = newName;
            }
        }

        public void AddGrade(string grade)
        {
            if (double.TryParse(grade, out double result))
            {
                this.AddGrade(result);
                Console.WriteLine($"Pomyślnie dodano ocenę : {result} dla pracownika {this.Name}");
            }
        }
        public void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"{grade} nie jest poprawną wartością. Ocena musi zawierać się w przedziale 0-100.");
            }
        }
        public void AddGrade(string grade, char v)
        {
            if (grade.Length == 3 && char.IsDigit(grade[0]) && grade[0] <= v && (grade[1] == '+' || grade[1] == '-'))
            {
                double convertedGradeToDouble = char.GetNumericValue(grade[0]);
                switch (grade[1])
                {
                    case '+':
                        double gradePlus = convertedGradeToDouble + 0.50;
                        if (gradePlus > 1 && gradePlus <= 95.5)
                        {
                            AddGrade(gradePlus);
                        }
                        else
                        {
                            throw new ArgumentException($"{grade} nie jest poprawną wartością. Ocena musi zawierać się w przedziale 0-100.");
                        }
                        break;

                    case '-':
                        double gradeMinus = convertedGradeToDouble - 0.25;
                        if (gradeMinus > 1 && gradeMinus <= 100)
                        {
                            AddGrade(gradeMinus);
                        }
                        else
                        {
                            throw new ArgumentException($"{grade} nie jest poprawną wartością. Ocena musi zawierać się w przedziale 0-100.");
                        }
                        break;

                    default:
                        throw new ArgumentException($"{grade} nie jest poprawną wartością. Ocena musi zawierać się w przedziale 0-100.");
                }
            }
            else
            {
                double gradeDouble = 0;
                var isParsed = double.TryParse(grade, out gradeDouble);
                if (isParsed && gradeDouble > 0 && gradeDouble <= 100)
                {
                    AddGrade(gradeDouble);
                }
                else
                {
                    throw new ArgumentException($"{grade} nie jest poprawną wartością. Ocena musi zawierać się w przedziale 0-100.");
                }
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;
            return result;
        }
    }
}












