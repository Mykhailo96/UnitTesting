using Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestFixture]
   public  class AlgoServiceTests
    {
        [Test]
        public void DoubleSum_When_given_a_and_b_Then_returns_2a_plus_2b()
        {
            //Arrange
            AlgoService algo = new AlgoService();
            var list = new List<int> { 2, 3 };

            //Act
            int x = algo.DoubleSum(list);
            int y = algo.DoubleSum(list);

            //Assert
            Assert.That(x, Is.EqualTo(10));
            Assert.That(algo.MethodsCalledCount, Is.EqualTo(2));
        }

        [Test]
        public void MinValue_When_given_a_and_b_Then_returns_b_if_a_bigger_then_b_otherwise_returns_a()
        {
            //Arrange
            AlgoService algo = new AlgoService();
            var list = new List<int> { 4, 2, 3 };

            //Act
            int min = algo.MinValue(list);

            //Assert
            Assert.That(min, Is.EqualTo(2));
        }

        [Test]
        public void Function_When_given_4_numbers_Then_returns_num4num4num4_plus_num1num3_minus_PiSqrtnum2()
        {
            //Arrange
            AlgoService algo = new AlgoService();

            //Act
            double num = algo.Function(3, 4.5, 2, 1);

            //Assert
            Assert.That(num, Is.InRange(0.335, 0.336));
        }

        [Test]
        public void GetAverage_When_given_list_Then_returns_average_value_from_list()
        {
            //Arrange
            var algo = new AlgoService();
            var list = new List<int> { 4, 15, 11 };

            //Act
            var aver = algo.GetAverage(list);

            //Assert
            Assert.That(aver, Is.EqualTo(10));
        }

        [Test]
        public void Sqr_When_given_value_Then_returns_square_of_value()
        {
            //Arrange
            var algo = new AlgoService();

            //Act
            var sqr = algo.Sqr(11);

            //Assert
            Assert.That(sqr, Is.EqualTo(121));
        }
    }
}
