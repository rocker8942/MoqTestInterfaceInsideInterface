using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqTest;

namespace MoqTestTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void MainTest()
        {
            var mockFoo = new Mock<IFoo>() { DefaultValue = DefaultValue.Mock };
            var bar = mockFoo.Object.Bar;

            var barMock = Mock.Get(bar);
            barMock.Setup(a => a.DoBar("id", "pass")).Returns("mocked");

            var p = new MoqTest.MoqTest(mockFoo.Object);
            var expected = "mocked";
            var actual = p.Run("id", "pass");

            Assert.AreEqual(expected, actual);
        }
    }
}