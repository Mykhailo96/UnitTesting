using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestFixture]
    public class DataServiceTests
    {
        private DataService ds;
        private int negVal = -5;

        [SetUp]
        public void SetCapacity()
        {
            //Arrange
            ds = new DataService(5);
            ds.AddItem(2);
            ds.AddItem(3);
        }

        [TearDown]
        public void Dispose()
        {
            ds.ClearAll();
        }

        [Test]
        public void ItemsCount_When_increase_capacity_Then_increases_ItemsCount()
        {
            //Act
            ds.AddItem(2);
            ds.AddItem(3);
            ds.AddItem(2);
            ds.AddItem(3);

            //Assert
            Assert.That(ds.ItemsCount, Is.EqualTo(6));
        }

        [Test]
        public void AddItem_When_given_param_Then_add_to_list()
        {
            //Act
            ds.AddItem(5);
            ds.AddItem(1);

            //Assert
            Assert.That(ds.ItemsCount, Is.EqualTo(4));
        }

        [Test]
        public void GetElementAt_When_given_int_Then_returns_number_on_this_position()
        {
            //Act
            int elem = ds.GetElementAt(1);

            //Assert
            Assert.That(elem, Is.EqualTo(3));
        }

        [Test]
        public void GetAllData_When_call_Then_returns_list_of_int()
        {

            //Act
            IEnumerable<int> list = ds.GetAllData();

            var ex = new List<int> { 2, 3 };

            //Assert
            Assert.AreEqual(ex, list);
        }

        [Test]
        public void RemoveAt_When_given_int_Then_deletes_number_on_this_position()
        {
            //Act
            ds.RemoveAt(0);

            //Assert
            Assert.That(ds.ItemsCount, Is.EqualTo(1));
        }

        [Test]
        public void ClearAll_When_call_Then_clears_list()
        {
            //Act
            ds.ClearAll();

            //Assert
            Assert.That(ds.ItemsCount, Is.EqualTo(0));
        }

        [Test]
        public void GetMax_When_call_Then_gets_max_element_in_list()
        {
            //Act
            int max = ds.GetMax();

            //Assert
            Assert.That(max, Is.EqualTo(3));
        }

       
        //For exceptions

        [Test]
        public void Ctor_When_pass_negative_value_Then_thow_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DataService(negVal));
        }

        [Test]
        public void GetElementAt_When_pass_negative_value_Then_thow_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ds.GetElementAt(negVal));
        }

        [Test]
        public void RemoveAt_When_pass_negative_value_Then_thow_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ds.RemoveAt(negVal));
        }
    }
}
