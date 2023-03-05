using System;
using BakeryApp;
using NUnit.Framework;
namespace BakeryApp.Tests
{
    public class PerformanceTests
    {
        [Test]
        public void Test1()
        {
            // arrange
            var baker = new BakeryInMemory("Wojtas", "Wojtasiñski");
            baker.AddPerformance(50.0);
            baker.AddPerformance(100.0);
            baker.AddPerformance(150.0);
            baker.AddPerformance(300.0);
            baker.AddPerformance(450.0);

            // act
            var result = baker.GetStatistics();

            // assert
            Assert.AreEqual(result.Average, 210);
            Assert.AreEqual(result.Max, 450);
            Assert.AreEqual(result.Min, 50);
        }

    }
}