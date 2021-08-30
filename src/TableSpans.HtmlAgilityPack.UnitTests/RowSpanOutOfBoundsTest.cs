using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TableSpans.HtmlAgilityPack.UnitTests
{
    [TestClass]
    public class RowSpanOutOfBoundsTest : TestBase
    {
        public RowSpanOutOfBoundsTest()
            : base("./files/rowspan-out-of-bounds.html")
        {
        }

        [TestMethod]
        public void TestNumberOfDimensions()
        {
            Assert.AreEqual(_array.Rank, 2, "Wrong number of dimensions");
        }

        [TestMethod]
        public void TestFirstDimensionBounds()
        {
            Assert.AreEqual(0, _array.GetLowerBound(0));
            Assert.AreEqual(1, _array.GetUpperBound(0));
        }

        [TestMethod]
        public void TestSecondDimensionBounds()
        {
            Assert.AreEqual(0, _array.GetLowerBound(1));
            Assert.AreEqual(1, _array.GetUpperBound(1));
        }

        // First Column

        [TestMethod]
        public void TestX0Y0()
        {
            Assert.AreEqual("A", _array[0, 0]);
        }

        [TestMethod]
        public void TestX0Y1()
        {
            Assert.AreEqual("C", _array[0, 1]);
        }
        // First Column

        [TestMethod]
        public void TestX1Y0()
        {
            Assert.AreEqual("B", _array[1, 0]);
        }

        [TestMethod]
        public void TestX1Y1()
        {
            Assert.AreEqual("B", _array[1, 1]);
        }
    }
}