using HtmlAgilityPack;
using System;

namespace TableSpans.HtmlAgilityPack.Demo
{
    public class Program
    {
        const string _html = @"
<table>
    <tr>
        <td colspan='2'>A</td>
        <td rowspan='2'>B</td>
    </tr>
    <tr>
        <td>C</td>
        <td>D</td>
    </tr>
</table>";

        static void Main(string[] args)
        {
            var tableSpansExtension = new TableSpansExtension();

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(_html);

            var tableNode = htmlDocument.DocumentNode.SelectSingleNode(".//table");
            if (tableNode == null)
            {
                throw new InvalidOperationException("Could not find a table");
            }

            var newTableNode = tableSpansExtension.ProcessTable(tableNode);

            tableNode.ParentNode.ReplaceChild(newTableNode, tableNode);

            /*
            <table>
                <tr>
                    <td colspan='2'>A</td>
                    <td rowspan='2'>B</td>
                </tr>
                <tr>
                    <td>C</td>
                    <td>D</td>
                </tr>
            </table>
            */
            var htmlTableNodeBefore = tableNode.OuterHtml;

            /*
            <table>
                <tr>
                    <td>A</td>
                    <td>A</td>
                    <td>B</td>
                </tr>
                <tr>
                    <td>C</td>
                    <td>D</td>
                    <td>B</td>
                </tr>
            </table>
            */
            var htmlTableNodeAfter = newTableNode.OuterHtml;

            /*    
		    [0, 0] "A"  [0, 1] "C"
		    [1, 0] "B"  [1, 1] "D"
            */
            var arrBefore = tableSpansExtension.ToArray(tableNode);

            /*
  		    [0, 0] "A"  [1, 0] "A"  [2, 0] "B"
		    [0, 1] "C"  [1, 1] "D"  [2, 1] "B"
            */
            var arrAfter = tableSpansExtension.ToArray(newTableNode);
        }
    }
}