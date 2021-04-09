using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
             Name = name;
           grades = new List<double>();
        }

        public void AddGrade(double grade) 
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
                
            }
        } 

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
           
           /*
           var index =0 ;
           do  
           {
                statisticsResult.High = Math.Max(grades[index], statisticsResult.High);
                statisticsResult.Low = Math.Min(grades[index], statisticsResult.Low);
                statisticsResult.Average += grades[index];
                index+=1;  
           } while(index < grades.Count);
            */
            /*
           var index =0 ;
           while(index < grades.Count)
           {
                statisticsResult.High = Math.Max(grades[index], statisticsResult.High);
                statisticsResult.Low = Math.Min(grades[index], statisticsResult.Low);
                statisticsResult.Average += grades[index];
                index+=1;  
           };
           */
           /*
           for(var index =0;index<grades.Count;index+=1)
           {
                statisticsResult.High = Math.Max(grades[index], statisticsResult.High);
                statisticsResult.Low = Math.Min(grades[index], statisticsResult.Low);
                statisticsResult.Average += grades[index];
                index+=1;  
           }
           */
           statisticsResult.Average /= grades.Count;

           switch(statisticsResult.Average)
           {
               case var d when d >= 90.0:
                    statisticsResult.Letter ='A';
                    break;

                case var d when d >= 80.0:
                    statisticsResult.Letter ='B';
                    break;

                case var d when d >= 70.0:
                    statisticsResult.Letter ='C';
                    break;

                case var d when d >= 60.0:
                    statisticsResult.Letter ='D';
                    break;

                default:
                    statisticsResult.Letter ='F';
                    break;
           }

           return statisticsResult;

        }
        
         private List<double> grades;

         public string Name
         {
             get
             {
                 return name;
             }
             set
             {
                 if(!String.IsNullOrEmpty(value))
                 {
                     name = value; 
                 }
                 else
                 {
                     throw new ArgumentNullException($"Null value received for {nameof(value)}");

                 }
                 
             }
         }
        private string name;

        /*
        Alternate smaller way to do this
        public string Name
        {
            get; set;
        }
        */
    }
}