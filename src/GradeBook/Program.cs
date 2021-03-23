using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Book book = new Book("Miguels Book");
            book.AddGrade(89.1);
            book.AddGrade(73.3);
            book.AddGrade(99.1);
            book.GetStatistics();


           

            
        }
    }
}
