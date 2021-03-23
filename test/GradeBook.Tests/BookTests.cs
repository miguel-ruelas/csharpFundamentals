using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            //Act
            var testResult = book.GetStatistics();

            //Assert
            Assert.Equal(85.6,testResult.Average, 1);
            Assert.Equal(90.5,testResult.High, 1);
            Assert.Equal(77.3,testResult.Low, 1);
        }
    }
}
