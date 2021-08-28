using HtmlAgilityPack;
using System;

// An extension for HtmlAgilityPack to handle collapsing rowspan and colspan into unique cells to aid in parsing tables.
// See: https://www.nuget.org/packages/TableSpans.HtmlAgilityPack/
// GitHub: https://github.com/terryjbutler/HtmlAgilityPack.Extensions.TableSpans
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

        static void PrintArray(object[,] arr)
        {
            for (int y = 0; y < arr.GetLength(1); y++)
            {
                for (int x = 0; x < arr.GetLength(0); x++)
                {
                    Console.Write($"[{x}, {y}] \"{arr[x, y]}\" ");
                }
                Console.WriteLine();
            }
        }

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
            htmlTableNodeBefore:
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
            Console.WriteLine("htmlTableNodeBefore:");
            Console.WriteLine(htmlTableNodeBefore);
            Console.WriteLine();

            /*
            htmlTableNodeAfter:
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
            Console.WriteLine("htmlTableNodeAfter:");
            Console.WriteLine(htmlTableNodeAfter);
            Console.WriteLine();

            /*    
            arrBefore:
            [0, 0] "A" [1, 0] "B"
            [0, 1] "C" [1, 1] "D"
            */
            var arrBefore = tableSpansExtension.ToArray(tableNode);
            Console.WriteLine("arrBefore:");
            PrintArray(arrBefore);
            Console.WriteLine();

            /*
            arrAfter:
            [0, 0] "A" [1, 0] "A" [2, 0] "B"
            [0, 1] "C" [1, 1] "D" [2, 1] "B"
            */
            var arrAfter = tableSpansExtension.ToArray(newTableNode);
            Console.WriteLine("arrAfter:");
            PrintArray(arrAfter);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}