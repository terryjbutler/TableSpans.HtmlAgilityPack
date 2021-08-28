using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TableSpans.HtmlAgilityPack.UnitTests
{
    [TestClass]
    public class BothMixedBasicTest : TestBase
    {
        public BothMixedBasicTest()
            : base("./files/both-mixed-basic.html")
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
            Assert.AreEqual(3, _array.GetUpperBound(1));
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
            Assert.AreEqual("A", _array[1, 0]);
        }

        [TestMethod]
        public void TestRow1Col3()
        {
            Assert.AreEqual("B", _array[2, 0]);
        }

        // Second Row

        [TestMethod]
        public void TestRow2Col1()
        {
            Assert.AreEqual("C", _array[0, 1]);
        }

        [TestMethod]
        public void TestRow2Col2()
        {
            Assert.AreEqual("D", _array[1, 1]);
        }

        [TestMethod]
        public void TestRow2Col3()
        {
            Assert.AreEqual("E", _array[2, 1]);
        }

        // Third Row

        [TestMethod]
        public void TestRow3Col1()
        {
            Assert.AreEqual("F", _array[0, 2]);
        }

        [TestMethod]
        public void TestRow3Col2()
        {
            Assert.AreEqual("G", _array[1, 2]);
        }

        [TestMethod]
        public void TestRow3Col3()
        {
            Assert.AreEqual("E", _array[2, 2]);
        }

        // Fourth Row

        [TestMethod]
        public void TestRow4Col1()
        {
            Assert.AreEqual("H", _array[0, 3]);
        }

        [TestMethod]
        public void TestRow4Col2()
        {
            Assert.AreEqual("I", _array[1, 3]);
        }

        [TestMethod]
        public void TestRow4Col3()
        {
            Assert.AreEqual("E", _array[2, 3]);
        }
    }
}