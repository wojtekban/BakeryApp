using System;
using BakeryApp;
using NUnit.Framework;

namespace BakeryApp.Tests
{
    public class TypeTests
    {
        [Test]
        public void TestWhenToAddIntegersThenCompareIfTheyAreEqual()
        {
            //arrange
            float baker1 = 100;
            float baker2 = 100;

            //act

            //assert
            Assert.AreEqual(baker1, baker2);

        }

        [Test]
        public void TestWhenToAddDecimalNumbersThenCompareIfTheyAreEqual()
        {
            //arrange
            double baker1 = 150.50;
            double baker2 = 150.50;

            //act

            //assert
            Assert.AreEqual(baker1, baker2);

        }

        [Test]
        public void WhenToAddUsersThenCompareIfTheyAreEqual()
        {
            //arrange
            var baker1 = GetPerson("Adam", "Wilczewski");
            var baker2 = GetPerson("Kasia", "Lisewska");

            //act

            //assert
            Assert.AreNotEqual(baker1, baker2);

        }
        private Person GetPerson(string name, string surName)
        {
            return new Person(name, surName);
        }

    }
}