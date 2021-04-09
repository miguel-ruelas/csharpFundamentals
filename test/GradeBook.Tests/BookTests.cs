using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //Arrange
            var book = new Book("Test");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            //Act
            var testResult = book.GetStatistics();

            //Assert
            Assert.Equal(85.6,testResult.Average, 1);
            Assert.Equal(90.5,testResult.High, 1);
            Assert.Equal(77.3,testResult.Low, 1);
            Assert.Equal('B', testResult.Letter);
        }
        /*

        [Fact]
        public void AddInvalidGrade()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(105);
            //Act
            var testResult = book.GetStatistics();

            //Assert
            Assert.Equal(85.6,testResult.Average, 1);
            Assert.Equal(90.5,testResult.High, 1);
            Assert.Equal(77.3,testResult.Low, 1);
        }
        */
    }
}
