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
        private AlgoService algo;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            algo = new AlgoService();
        }

        [Test]
        [TestCase("2,3")]
        [TestCase("4,5,6")]
        public void DoubleSum_When_given_a_and_b_Then_returns_2a_plus_2b(string str)
        {
            //Arrange
            var list = str.Split(',').Select(int.Parse).ToList();

            var ans = list.Sum(i => i * 2);

            ////Act
            int x = algo.DoubleSum(list);

            //Assert
            Assert.That(x, Is.EqualTo(ans));
        }

        [Test]
        [TestCase(2)]
        [TestCase(5)]
        public void MethodsCalledCount_When_any_method_called_Then_gives_numbers_of_calls(int calls)
        {
            //Act
            for (int i = 0; i < calls; i++)
            {
                algo.Sqr(2);
            }

            //Assert
            Assert.That(algo.MethodsCalledCount, Is.EqualTo(calls));
        }

        [Test]
        [TestCase("2,3")]
        [TestCase("4,5,6")]
        public void MinValue_When_given_a_and_b_Then_returns_b_if_a_bigger_then_b_otherwise_returns_a(string str)
        {
            //Arrange
            var list = str.Split(',').Select(int.Parse).ToList();
            var ans = list.Min();

            //Act
            int min = algo.MinValue(list);

            //Assert
            Assert.That(min, Is.EqualTo(ans));
        }

        [Test]
        public void Function_When_given_4_numbers_Then_returns_num4num4num4_plus_num1num3_minus_PiSqrtnum2()
        {
            //Act
            double num = algo.Function(3, 4.5, 2, 1);

            //Assert
            Assert.That(num, Is.InRange(0.335, 0.336));
        }

        [Test]
        [TestCase("12,3,21,4", ExpectedResult = 10)]
        [TestCase("6,17,7,16", ExpectedResult = 11.5)]
        public double GetAverage_When_given_list_Then_returns_average_value_from_list(string str)
        {
            //Arrange
            var list = str.Split(',').Select(int.Parse).ToList();

            //Act
            var aver = algo.GetAverage(list);

            //Assert
            return aver;
        }

        [Test]
        [TestCase(3)]
        [TestCase(-12)]
        public void Sqr_When_given_value_Then_returns_square_of_value(int number)
        {
            //Act
            var sqr = algo.Sqr(number);
            var ans = Math.Pow(number, 2);

            //Assert
            Assert.That(sqr, Is.EqualTo(ans));
        }

        //Param list is empty

        [Test]
        public void DoubleSum_When_pass_empty_list_Then_returns_0()
        {
            //Arrange
            var list = new List<int>();

            ////Act
            int x = algo.DoubleSum(list);

            //Assert
            Assert.That(x, Is.EqualTo(0));
        }

        //For exceptions

        [Test]
        public void MinValue_When_pass_empty_list_Then_returns_0()
        {
            //Arrange
            var list = new List<int>();

            //Assert
            Assert.Throws<InvalidOperationException>(() => algo.MinValue(list));
        }

        [Test]
        public void GetAverage_When_pass_empty_list_Then_returns_0()
        {
            //Arrange
            var list = new List<int>();

            //Assert
            Assert.Throws<InvalidOperationException>(() => algo.GetAverage(list));
        }

        [Test]
        public void DoubleSum_When_pass_null_Then_thow_exception()
        {
            List<int> nullList = null;

            Assert.Throws<ArgumentNullException>(() => algo.DoubleSum(nullList));
        }

        [Test]
        public void MinValue_When_pass_null_Then_thow_exception()
        {
            List<int> nullList = null;

            Assert.Throws<ArgumentNullException>(() => algo.MinValue(nullList));
        }

        [Test]
        public void GetAverage_When_pass_null_Then_thow_exception()
        {
            List<int> nullList = null;

            Assert.Throws<ArgumentNullException>(() => algo.GetAverage(nullList));
        }

        [Test]
        public void Function_second_param_negative_Then_thow_exception()
        {
            Assert.Throws<InvalidOperationException>(() => algo.Function(3, -4.5, 2, 1));
        }




        public static bool IsNullOrEmpty(IEnumerable<int> enumerable)
        {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }
    }
}
