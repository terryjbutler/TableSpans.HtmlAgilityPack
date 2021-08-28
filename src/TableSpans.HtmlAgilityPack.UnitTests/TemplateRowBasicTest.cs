using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TableSpans.HtmlAgilityPack.UnitTests
{
    [TestClass]
    public class TemplateRowSpanTest : TestBase
    {
        public TemplateRowSpanTest()
            : base("./files/template-starter.html")
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
            Assert.AreEqual(6, _array.GetUpperBound(0));
        }

        [TestMethod]
        public void TestSecondDimensionBounds()
        {
            Assert.AreEqual(0, _array.GetLowerBound(1));
            Assert.AreEqual(6, _array.GetUpperBound(1));
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
            Assert.AreEqual("(0,1)", _array[0, 1]);
        }

        [TestMethod]
        public void TestX0Y2()
        {
            Assert.AreEqual("(0,2)", _array[0, 2]);
        }

        [TestMethod]
        public void TestX0Y3()
        {
            Assert.AreEqual("(0,3)", _array[0, 3]);
        }

        [TestMethod]
        public void TestX0Y4()
        {
            Assert.AreEqual("(0,4)", _array[0, 4]);
        }

        [TestMethod]
        public void TestX0Y5()
        {
            Assert.AreEqual("(0,5)", _array[0, 5]);
        }

        [TestMethod]
        public void TestX0Y6()
        {
            Assert.AreEqual("(0,6)", _array[0, 6]);
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
            Assert.AreEqual("(1,1)", _array[1, 1]);
        }

        [TestMethod]
        public void TestX1Y2()
        {
            Assert.AreEqual("(1,2)", _array[1, 2]);
        }

        [TestMethod]
        public void TestX1Y3()
        {
            Assert.AreEqual("(1,3)", _array[1, 3]);
        }

        [TestMethod]
        public void TestX1Y4()
        {
            Assert.AreEqual("(1,4)", _array[1, 4]);
        }

        [TestMethod]
        public void TestX1Y5()
        {
            Assert.AreEqual("(1,5)", _array[1, 5]);
        }

        [TestMethod]
        public void TestX1Y6()
        {
            Assert.AreEqual("(1,6)", _array[1, 6]);
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

        [TestMethod]
        public void TestX2Y3()
        {
            Assert.AreEqual("(2,3)", _array[2, 3]);
        }

        [TestMethod]
        public void TestX2Y4()
        {
            Assert.AreEqual("(2,4)", _array[2, 4]);
        }

        [TestMethod]
        public void TestX2Y5()
        {
            Assert.AreEqual("(2,5)", _array[2, 5]);
        }

        [TestMethod]
        public void TestX2Y6()
        {
            Assert.AreEqual("(2,6)", _array[2, 6]);
        }

        // Fourth Column

        [TestMethod]
        public void TestX3Y0()
        {
            Assert.AreEqual("(3,0)", _array[3, 0]);
        }

        [TestMethod]
        public void TestX3Y1()
        {
            Assert.AreEqual("(3,1)", _array[3, 1]);
        }

        [TestMethod]
        public void TestX3Y2()
        {
            Assert.AreEqual("(3,2)", _array[3, 2]);
        }

        [TestMethod]
        public void TestX3Y3()
        {
            Assert.AreEqual("(3,3)", _array[3, 3]);
        }

        [TestMethod]
        public void TestX3Y4()
        {
            Assert.AreEqual("(3,4)", _array[3, 4]);
        }

        [TestMethod]
        public void TestX3Y5()
        {
            Assert.AreEqual("(3,5)", _array[3, 5]);
        }

        [TestMethod]
        public void TestX3Y6()
        {
            Assert.AreEqual("(3,6)", _array[3, 6]);
        }

        // Fifth Column

        [TestMethod]
        public void TestX4Y0()
        {
            Assert.AreEqual("(4,0)", _array[4, 0]);
        }

        [TestMethod]
        public void TestX4Y1()
        {
            Assert.AreEqual("(4,1)", _array[4, 1]);
        }

        [TestMethod]
        public void TestX4Y2()
        {
            Assert.AreEqual("(4,2)", _array[4, 2]);
        }

        [TestMethod]
        public void TestX4Y3()
        {
            Assert.AreEqual("(4,3)", _array[4, 3]);
        }

        [TestMethod]
        public void TestX4Y4()
        {
            Assert.AreEqual("(4,4)", _array[4, 4]);
        }

        [TestMethod]
        public void TestX4Y5()
        {
            Assert.AreEqual("(4,5)", _array[4, 5]);
        }
        [TestMethod]
        public void TestX4Y6()
        {
            Assert.AreEqual("(4,6)", _array[4, 6]);
        }

        // Sixth Column

        [TestMethod]
        public void TestX5Y0()
        {
            Assert.AreEqual("(5,0)", _array[5, 0]);
        }

        [TestMethod]
        public void TestX5Y1()
        {
            Assert.AreEqual("(5,1)", _array[5, 1]);
        }

        [TestMethod]
        public void TestX5Y2()
        {
            Assert.AreEqual("(5,2)", _array[5, 2]);
        }

        [TestMethod]
        public void TestX5Y3()
        {
            Assert.AreEqual("(5,3)", _array[5, 3]);
        }

        [TestMethod]
        public void TestX5Y4()
        {
            Assert.AreEqual("(5,4)", _array[5, 4]);
        }

        [TestMethod]
        public void TestX5Y5()
        {
            Assert.AreEqual("(5,5)", _array[5, 5]);
        }

        [TestMethod]
        public void TestX5Y6()
        {
            Assert.AreEqual("(5,6)", _array[5, 6]);
        }

        // Seventh Column

        [TestMethod]
        public void TestX6Y0()
        {
            Assert.AreEqual("(6,0)", _array[6, 0]);
        }

        [TestMethod]
        public void TestX6Y1()
        {
            Assert.AreEqual("(6,1)", _array[6, 1]);
        }

        [TestMethod]
        public void TestX6Y2()
        {
            Assert.AreEqual("(6,2)", _array[6, 2]);
        }

        [TestMethod]
        public void TestX6Y3()
        {
            Assert.AreEqual("(6,3)", _array[6, 3]);
        }

        [TestMethod]
        public void TestX6Y4()
        {
            Assert.AreEqual("(6,4)", _array[6, 4]);
        }

        [TestMethod]
        public void TestX6Y5()
        {
            Assert.AreEqual("(6,5)", _array[6, 5]);
        }

        [TestMethod]
        public void TestX6Y6()
        {
            Assert.AreEqual("(6,6)", _array[6, 6]);
        }
    }
}