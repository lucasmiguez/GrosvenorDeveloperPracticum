using System.Collections.Generic;
using System.Linq;
using Application;
using NUnit.Framework;


namespace ApplicationTests
{
    [TestFixture]
    public class DishManagerTests
    {
        private DishManagerMorning _dishMorning;

        [SetUp]
        public void Setup()
        {
            _dishMorning = new DishManagerMorning();
        }

        [Test]
        public void EmptyListReturnsEmptyList()
        {
            var order = new Order();
            var actual = _dishMorning.GetDishes(order);
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void ListWith1ReturnsOneEgg()
        {
            var order = new Order
            {
                Dishes = new List<int>
                {
                    1
                }
            };

            var actual = _dishMorning.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("egg", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }
    }
}
