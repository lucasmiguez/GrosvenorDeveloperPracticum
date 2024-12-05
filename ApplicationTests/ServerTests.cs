using Application;
using NUnit.Framework;
using System.Globalization;

namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;
        
        [SetUp]
        public void Setup()
        {
            _sut = new Server(new DishManagerMorning(),new MenuFactory());
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        [TestCase("morning")]
        [TestCase("evening")]
        public void ErrorGetsReturnedWithBadInput(string period)
        {
            var order = "one";
            string expected = "error";
            var actual = _sut.TakeOrder("Morning", order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("evening")]
        public void CanServeSteak(string period)
        {
            var order = "1";
            string expected = "steak";
            var actual = _sut.TakeOrder(period, order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("evening")]
        public void CanServe2Potatoes(string period)
        {
            var order = "2,2";
            string expected = "potato(x2)";
            var actual = _sut.TakeOrder(period, order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("evening")]
        public void CanServeSteakPotatoWineCake(string period)
        {
            var order = "1,2,3,4";
            string expected = "steak,potato,wine,cake";
            var actual = _sut.TakeOrder(period, order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("evening")]
        public void CanServeSteakPotatox2Cake(string period)
        {
            var order = "1,2,2,4";
            string expected = "steak,potato(x2),cake";
            var actual = _sut.TakeOrder(period, order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("morning")]
        public void CanGenerateErrorWithWrongDish(string period)
        {
            var order = "1,2,3,5";
            string expected = "error";
            var actual = _sut.TakeOrder(period, order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("morning")]
        public void CanGenerateErrorWhenTryingToServerMoreThanOneSteak(string period)
        {
            var order = "1,1,2,3";
            string expected = "error";
            var actual = _sut.TakeOrder(period, order);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase("morning")]
        public void CanGenerateOrderWithoutToast(string period)
        {
            var order = "1,0,3";
            string expected = "egg,coffee";
            var actual = _sut.TakeOrder(period, order);
            Assert.AreEqual(expected, actual);
        }



    }
}