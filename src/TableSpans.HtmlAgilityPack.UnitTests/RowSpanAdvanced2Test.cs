using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TableSpans.HtmlAgilityPack.UnitTests
{
    [TestClass]
    public class RowSpanAdvanced2Test : TestBase
    {
        public RowSpanAdvanced2Test()
            : base("./files/rowspan-advanced-2.html")
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
            Assert.AreEqual(2, _array.GetUpperBound(0));
        }

        [TestMethod]
        public void TestSecondDimensionBounds()
        {
            Assert.AreEqual(0, _array.GetLowerBound(1));
            Assert.AreEqual(2, _array.GetUpperBound(1));
        }

        // First Column

        [TestMethod]
        public void TestX0Y0()
        {
            Assert.AreEqual("(0,0)", _array[0, 0]);
        }

        [TestMethod]
        public void TestX0Y1()
        {
            Assert.AreEqual("(0,1) > (0,2)", _array[0, 1]);
        }

        [TestMethod]
        public void TestX0Y2()
        {
            Assert.AreEqual("(0,1) > (0,2)", _array[0, 2]);
        }

        // Second Column

        [TestMethod]
        public void TestX1Y0()
        {
            Assert.AreEqual("(1,0)", _array[1, 0]);
        }

        [TestMethod]
        public void TestX1Y1()
        {
            Assert.AreEqual("(1,1) > (1,2)", _array[1, 1]);
        }

        [TestMethod]
        public void TestX1Y2()
        {
            Assert.AreEqual("(1,1) > (1,2)", _array[1, 2]);
        }

        // Third Column

        [TestMethod]
        public void TestX2Y0()
        {
            Assert.AreEqual("(2,0)", _array[2, 0]);
        }

        [TestMethod]
        public void TestX2Y1()
        {
            Assert.AreEqual("(2,1)", _array[2, 1]);
        }

        [TestMethod]
        public void TestX2Y2()
        {
            Assert.AreEqual("(2,2)", _array[2, 2]);
        }
    }
}