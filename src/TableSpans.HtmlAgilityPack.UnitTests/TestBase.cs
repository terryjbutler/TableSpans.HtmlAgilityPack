using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TableSpans.HtmlAgilityPack.UnitTests
{
    public abstract class TestBase
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        public TestBase(string path)
        {
            _path = path;
        }

        private readonly string _path;

        protected readonly TableSpansExtension _tableSpanHelper = new TableSpansExtension();
        protected readonly HtmlDocument _htmlDocument = new HtmlDocument();
        protected string[,] _array = new string[0, 0];

        [TestInitialize]
        public void Init()
        {
            _htmlDocument.Load(_path);

            var tableNode = _htmlDocument.DocumentNode.SelectSingleNode(".//table");
            if (tableNode == null)
            {
                throw new InvalidOperationException("Could not find a table");
            }

            var newTableNode = _tableSpanHelper.ProcessTable(tableNode);

            _array = _tableSpanHelper.ToArray(newTableNode);

            Assert.IsNotNull(_array);

            tableNode.ParentNode.ReplaceChild(newTableNode, tableNode);
        }

        [TestMethod]
        public void __TestOutput__()
        {
            var html = _htmlDocument.DocumentNode.OuterHtml;

            var basePath = Path.GetFullPath(Path.GetDirectoryName(_path));
            var path = Path.GetFullPath(@".\..\..\..\..\", basePath);
            var filename = Path.GetFileNameWithoutExtension(_path);
            var ext = Path.GetExtension(_path);

            File.WriteAllText($@"{path}\files\{filename}.processed{ext}", html);

            TestContext.Write(html);
        }
    }
}