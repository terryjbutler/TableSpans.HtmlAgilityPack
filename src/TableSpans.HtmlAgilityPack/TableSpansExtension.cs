using HtmlAgilityPack;
using System;
using System.Linq;

namespace TableSpans.HtmlAgilityPack
{
    public class TableSpansExtension
    {
        /// <summary>
        /// Processes a given table collapsing rowspan and colspan into unique cells to aid in parsing tables.
        /// </summary>
        /// <param name="tableNode">Should be a HtmlNode of a table type. This function doesn't mutate this param. It is cloned and a modified copied is returned.</param>
        /// <returns>Returns the processed table as a newly cloned HtmlNode object.</returns>
        public HtmlNode ProcessTable(in HtmlNode tableNode)
        {
            if (!tableNode.Name.Equals("table"))
            {
                return tableNode;
            }

            var ret = tableNode.Clone();

            var rows = ret.SelectNodes(".//tr");

            // Build ColSpans
            for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                HtmlNode row = rows[rowIndex];

                var cells = row.SelectNodes(".//td|.//th");

                for (int colIndex = 0; colIndex < cells.Count; colIndex++)
                {
                    HtmlNode cell = cells[colIndex];

                    var colspan = cell.GetAttributeValue("colspan", 0);

                    if (colspan > 0)
                    {
                        cell.Attributes["colspan"]?.Remove();

                        for (int i = 1; i < colspan; i++)
                        {
                            var newCell = HtmlNode.CreateNode(cell.OuterHtml);

                            row.InsertAfter(newCell, cell);
                        }
                    }
                }
            }

            // Calculate the maximum number of rows and columns currently in the table after colspan rebuilding
            var numRows = rows.Count;
            var numCols = rows
                .Select(row => row.SelectNodes(".//td|.//th"))
                .Max(a => a.Count);

            // Build RowSpans
            for (int colIndex = 0; colIndex < numCols; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
                {
                    HtmlNode row = rows[rowIndex];

                    var cells = row.SelectNodes(".//td|.//th");

                    HtmlNode cell = cells[colIndex];

                    var rowspan = cell.GetAttributeValue("rowspan", 0);

                    if (rowspan > 0)
                    {
                        cell.Attributes["rowspan"]?.Remove();

                        for (int i = 1; i < rowspan; i++)
                        {
                            var subRow = rows[rowIndex + i];
                            var subRowCells = subRow.SelectNodes(".//td|.//th");

                            var newCell = HtmlNode.CreateNode(cell.OuterHtml);

                            var targetCellIndex = Math.Min(subRowCells.Count - 1, colIndex);
                            var targetCell = subRowCells[targetCellIndex];

                            if (colIndex > subRowCells.Count - 1)
                            {
                                subRow.InsertAfter(newCell, targetCell);
                            }
                            else
                            {
                                subRow.InsertBefore(newCell, targetCell);
                            }
                        }
                    }
                }
            }

            return ret;
        }

        public string[,] ToArray(in HtmlNode tableNode)
        {
            var rows = tableNode.SelectNodes(".//tr");
            var numRows = rows.Count;
            var numCols = 0;

            string[,] ret;

            foreach (var row in rows)
            {
                var cols = row.SelectNodes(".//td|.//th");

                if (cols.Count() > numCols)
                {
                    numCols = cols.Count;
                }
            }

            ret = new string[numCols, numRows];

            for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                HtmlNode row = rows[rowIndex];

                var cols = row.SelectNodes(".//td|.//th");

                for (int colIndex = 0; colIndex < cols.Count; colIndex++)
                {
                    HtmlNode col = cols[colIndex];

                    ret[colIndex, rowIndex] = col.InnerText;
                }
            }

            return ret;
        }
    }
}