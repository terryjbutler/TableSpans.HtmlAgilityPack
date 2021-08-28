using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TableSpans.HtmlAgilityPack.UnitTests
{
    [TestClass]
    public class BothMixedAdvancedTest : TestBase
    {
        public BothMixedAdvancedTest()
            : base("./files/both-mixed-advanced.html")
        {
        }

        [TestMethod]
        public void TestNumberOfDimensions()
        {
            Assert.AreEqual(_array.Rank, 2, "Wrong number of dimensions");
        }

        [TestMethod]
        public void TestDimensionBounds0()
        {
            Assert.AreEqual(0, _array.GetLowerBound(0));
            Assert.AreEqual(4, _array.GetUpperBound(0));
        }

        [TestMethod]
        public void TestDimensionBounds1()
        {
            Assert.AreEqual(0, _array.GetLowerBound(1));
            Assert.AreEqual(7, _array.GetUpperBound(1));
        }

        // First Row

        [TestMethod]
        public void TestRow1Col1()
        {
            Assert.AreEqual("1", _array[0, 0]);
        }

        [TestMethod]
        public void TestRow1Col2()
        {
            Assert.AreEqual("2", _array[1, 0]);
        }

        [TestMethod]
        public void TestRow1Col3()
        {
            Assert.AreEqual("2", _array[2, 0]);
        }

        [TestMethod]
        public void TestRow1Col4()
        {
            Assert.AreEqual("3", _array[3, 0]);
        }

        [TestMethod]
        public void TestRow1Col5()
        {
            Assert.AreEqual("3", _array[4, 0]);
        }

        // Second Row

        [TestMethod]
        public void TestRow2Col1()
        {
            Assert.AreEqual("4", _array[0, 1]);
        }

        [TestMethod]
        public void TestRow2Col2()
        {
            Assert.AreEqual("4", _array[1, 1]);
        }

        [TestMethod]
        public void TestRow2Col3()
        {
            Assert.AreEqual("5", _array[2, 1]);
        }

        [TestMethod]
        public void TestRow2Col4()
        {
            Assert.AreEqual("5", _array[3, 1]);
        }


        [TestMethod]
        public void TestRow2Col5()
        {
            Assert.AreEqual("5", _array[4, 1]);
        }

        // Third Row

        [TestMethod]
        public void TestRow3Col1()
        {
            Assert.AreEqual("4", _array[0, 2]);
        }

        [TestMethod]
        public void TestRow3Col2()
        {
            Assert.AreEqual("4", _array[1, 2]);
        }

        [TestMethod]
        public void TestRow3Col3()
        {
            Assert.AreEqual("6", _array[2, 2]);
        }

        [TestMethod]
        public void TestRow3Col4()
        {
            Assert.AreEqual("6", _array[3, 2]);
        }

        [TestMethod]
        public void TestRow3Col5()
        {
            Assert.AreEqual("7", _array[4, 2]);
        }

        // Fourth Row

        [TestMethod]
        public void TestRow4Col1()
        {
            Assert.AreEqual("8", _array[0, 3]);
        }

        [TestMethod]
        public void TestRow4Col2()
        {
            Assert.AreEqual("9", _array[1, 3]);
        }

        [TestMethod]
        public void TestRow4Col3()
        {
            Assert.AreEqual("10", _array[2, 3]);
        }

        [TestMethod]
        public void TestRow4Col4()
        {
            Assert.AreEqual("11", _array[3, 3]);
        }

        [TestMethod]
        public void TestRow4Col5()
        {
            Assert.AreEqual("7", _array[4, 3]);
        }

        // Fifth Row

        [TestMethod]
        public void TestRow5Col1()
        {
            Assert.AreEqual("8", _array[0, 4]);
        }

        [TestMethod]
        public void TestRow5Col2()
        {
            Assert.AreEqual("12", _array[1, 4]);
        }

        [TestMethod]
        public void TestRow5Col3()
        {
            Assert.AreEqual("12", _array[2, 4]);
        }

        [TestMethod]
        public void TestRow5Col4()
        {
            Assert.AreEqual("11", _array[3, 4]);
        }

        [TestMethod]
        public void TestRow5Col5()
        {
            Assert.AreEqual("7", _array[4, 4]);
        }

        // Sixth Row

        [TestMethod]
        public void TestRow6Col1()
        {
            Assert.AreEqual("8", _array[0, 5]);
        }

        [TestMethod]
        public void TestRow6Col2()
        {
            Assert.AreEqual("13", _array[1, 5]);
        }

        [TestMethod]
        public void TestRow6Col3()
        {
            Assert.AreEqual("14", _array[2, 5]);
        }

        [TestMethod]
        public void TestRow6Col4()
        {
            Assert.AreEqual("14", _array[3, 5]);
        }

        [TestMethod]
        public void TestRow6Col5()
        {
            Assert.AreEqual("14", _array[4, 5]);
        }

        // Sixth Row

        [TestMethod]
        public void TestRow7Col1()
        {
            Assert.AreEqual("8", _array[0, 6]);
        }

        [TestMethod]
        public void TestRow7Col2()
        {
            Assert.AreEqual("13", _array[1, 6]);
        }

        [TestMethod]
        public void TestRow7Col3()
        {
            Assert.AreEqual("15", _array[2, 6]);
        }

        [TestMethod]
        public void TestRow7Col4()
        {
            Assert.AreEqual("15", _array[3, 6]);
        }

        [TestMethod]
        public void TestRow7Col5()
        {
            Assert.AreEqual("16", _array[4, 6]);
        }

        // Sixth Row

        [TestMethod]
        public void TestRow8Col1()
        {
            Assert.AreEqual("8", _array[0, 7]);
        }

        [TestMethod]
        public void TestRow8Col2()
        {
            Assert.AreEqual("13", _array[1, 7]);
        }

        [TestMethod]
        public void TestRow8Col3()
        {
            Assert.AreEqual("17", _array[2, 7]);
        }

        [TestMethod]
        public void TestRow8Col4()
        {
            Assert.AreEqual("17", _array[3, 7]);
        }

        [TestMethod]
        public void TestRow8Col5()
        {
            Assert.AreEqual("17", _array[4, 7]);
        }
    }
}