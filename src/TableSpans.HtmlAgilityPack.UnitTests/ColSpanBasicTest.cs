using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TableSpans.HtmlAgilityPack.UnitTests
{
    [TestClass]
    public class ColSpanBasicTest : TestBase
    {
        public ColSpanBasicTest()
            : base("./files/colspan-basic.html")
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
            Assert.AreEqual(4, _array.GetUpperBound(0));
        }

        [TestMethod]
        public void TestSecondDimensionBounds()
        {
            Assert.AreEqual(0, _array.GetLowerBound(1));
            Assert.AreEqual(1, _array.GetUpperBound(1));
        }

        // First Row

        [TestMethod]
        public void TestRow1Col1()
        {
            Assert.AreEqual("A", _array[0, 0]);
        }

        [TestMethod]
        public void TestRow1Col2()
        {
            Assert.AreEqual("B", _array[1, 0]);
        }

        [TestMethod]
        public void TestRow1Col3()
        {
            Assert.AreEqual("B", _array[2, 0]);
        }

        [TestMethod]
        public void TestRow1Col4()
        {
            Assert.AreEqual("B", _array[3, 0]);
        }

        [TestMethod]
        public void TestRow1Col5()
        {
            Assert.AreEqual("C", _array[4, 0]);
        }

        // Second Row

        [TestMethod]
        public void TestRow2Col1()
        {
            Assert.AreEqual("D", _array[0, 1]);
        }

        [TestMethod]
        public void TestRow2Col2()
        {
            Assert.AreEqual("E", _array[1, 1]);
        }

        [TestMethod]
        public void TestRow2Col3()
        {
            Assert.AreEqual("F", _array[2, 1]);
        }

        [TestMethod]
        public void TestRow2Col4()
        {
            Assert.AreEqual("G", _array[3, 1]);
        }

        [TestMethod]
        public void TestRow2Col5()
        {
            Assert.AreEqual("H", _array[4, 1]);
        }
    }
}