using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegeate(object sender, EventArgs args);

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegeate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegeate GradeAdded;

    }



    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegeate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }



        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line!= null)
                {
                    var number = double.Parse(line);                 
                    result.Add(number);
                    line = reader.ReadLine();

                }
            }
            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }
        public override event GradeAddedDelegeate GradeAdded;

        public void AddGrade(char letter)
        {
            switch (letter)
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


        public override Statistics GetStatistics()
        {
            var statisticsResult = new Statistics();



            foreach (double grade in grades)
            {
                statisticsResult.Add(grade);

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




            return statisticsResult;

        }

        private List<double> grades;

        /*
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
       */

        /*
        Alternate smaller way to do this
        public string Name
        {
            get; set;
        }
        */
    }
}