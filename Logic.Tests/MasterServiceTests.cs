using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using FakeItEasy;
using NUnit.Framework;

namespace Logic.Tests
{
    public class MasterServiceTests
    {
        private IDataService dataService;
        private IAlgoService algoService;
        private MasterService masterService;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            dataService = A.Fake<IDataService>();
            algoService = A.Fake<IAlgoService>();
            masterService = new MasterService(algoService, dataService);
        }

        [Test]
        public void GetDoubleSum_When_call_Then_returns_2xSum_list_of_DataService()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(new List<int> { 2, 3, 4 });
            A.CallTo(() => algoService.DoubleSum(A<List<int>>._)).Returns(18);
            int dSum = masterService.GetDoubleSum();

            //Assert
            Assert.That(dSum, Is.EqualTo(4 + 6 + 8));
        }

        [Test]
        public void GetAverage_When_call_Then_return_average_num_of_DataService()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(new List<int> { 2, 3, 4 });
            A.CallTo(() => algoService.GetAverage(A<List<int>>._)).Returns(3);
            var aver = masterService.GetAverage();

            //Assert
            Assert.That(aver, Is.EqualTo(3));
        }

        [Test]
        public void GetMaxSquare_When_call_Then_return_square_of_max_elem_in_DataService()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(new List<int> { 2, 3, 4 });
            A.CallTo(() => dataService.GetMax()).Returns(5);
            A.CallTo(() => algoService.Sqr(A<int>._)).Returns(25);
            var mSqr = masterService.GetMaxSquare();

            //Assert
            Assert.That(mSqr, Is.EqualTo(25));
        }

        [Test]
        public void GetMinSquare_When_call_Then_return_square_of_min_elem_in_DataService()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(new List<int> { 2, 3, 4 });
            A.CallTo(() => algoService.MinValue(A<List<int>>._)).Returns(2);
            A.CallTo(() => algoService.Sqr(A<int>._)).Returns(25);
            var mSqr = masterService.GetMinSquare();

            //Assert
            Assert.That(mSqr, Is.EqualTo(25));
        }

        [Test]
        public void SqrGetElementAt_When_given_number_Then_returns_sqr_of_element_on_position_number()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(new List<int> { 2, 3, 4 });
            A.CallTo(() => dataService.GetElementAt(A<int>._)).Returns(3);
            A.CallTo(() => algoService.Sqr(A<int>._)).Returns(49);

            //Assert
            Assert.That(masterService.SqrGetElementAt(2), Is.EqualTo(49));
        }

        //For exceptioins

        [Test]
        public void GetDoubleSum_When_DataService_does_not_have_any_data_Then_throws_exception()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(null);

            //Assert
            Assert.Throws(typeof(InvalidOperationException), () => masterService.GetDoubleSum());
        }

        [Test]
        public void GetAverage_When_DataService_does_not_have_any_data_Then_throws_exception()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(null);

            //Assert
            Assert.Throws(typeof(InvalidOperationException), () => masterService.GetAverage());
        }

        [Test]
        public void GetMaxSquare_When_DataService_does_not_have_any_data_Then_throws_exception()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(null);

            //Assert
            Assert.Throws(typeof(InvalidOperationException), () => masterService.GetMaxSquare());
        }

        [Test]
        public void GetMinSquare_When_DataService_does_not_have_any_data_Then_throws_exception()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(null);

            //Assert
            Assert.Throws(typeof(InvalidOperationException), () => masterService.GetMinSquare());
        }

        [Test]
        public void SqrGetElementAt_When_DataService_does_not_have_any_data_Then_throws_exception()
        {
            //Act
            A.CallTo(() => dataService.GetAllData()).Returns(null);

            //Assert
            Assert.Throws(typeof(InvalidOperationException), () => masterService.SqrGetElementAt(A<int>._));
        }
    }
}
