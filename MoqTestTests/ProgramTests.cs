using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqTest;

namespace MoqTestTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_RecursiveMock()
        {
            var mockFoo = new Mock<IFoo>() { DefaultValue = DefaultValue.Mock };
            var bar = mockFoo.Object.Bar;

            var barMock = Mock.Get(bar);
            barMock.Setup(a => a.DoBar("id", "pass")).Returns("mocked");

            var test = new MoqTest.MoqTest(mockFoo.Object);
            var expected = "mocked";
            var actual = test.Run("id", "pass");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SimpleMock()
        {
            var mockFoo = new Mock<IFoo>();
            mockFoo.Setup(a => a.DoFoo()).Returns("tested");
            var test = new MoqTest.MoqTest(mockFoo.Object);
            var expected = "tested";
            var actual = test.RunSimple();

            Assert.AreEqual(expected, actual);
        }
    }
}