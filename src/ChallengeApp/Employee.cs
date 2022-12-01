using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Employee
    {
        private string name;
        private List<double> grades = new List<double>();

        public Employee(string name)
        {
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }
        
        public string Name
        {
            get
            {
                return this.name;
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