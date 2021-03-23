using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
             this.name = name;
           grades = new List<double>();
        }

        public void AddGrade(double grade) => grades.Add(grade);

        public Statistics GetStatistics()
        {
            var statisticsResult= new Statistics();
            
           statisticsResult.Average = 0.0;
           statisticsResult.High = double.MinValue;
           statisticsResult.Low = double.MaxValue;

           foreach(double grade in grades)
           {
                statisticsResult.High = Math.Max(grade, statisticsResult.High);
                statisticsResult.Low = Math.Min(grade, statisticsResult.Low);
                statisticsResult.Average += grade;  
           }
           statisticsResult.Average /= grades.Count;

           return statisticsResult;

        }
        
         private List<double> grades;
        private string name;
    }
}