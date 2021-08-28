# TableSpans.HtmlAgilityPack

An extension for HtmlAgilityPack to handle collapsing rowspan and colspan into unique cells to aid in parsing tables.

If you try to parse a table that makes use of colspans or rowspans, you'll find the results of the parsing fail completely. This package rebuilds the individual cells duplicating the results across the missing cells.

![TableSpans.HtmlAgilityPack Demo](https://raw.githubusercontent.com/terryjbutler/TableSpans.HtmlAgilityPack/master/docs/images/TableSpans.HtmlAgilityPack-Demo.png)

## Basic Example

```csharp
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

            /*    
            arrBefore:
            [0, 0] "A" [1, 0] "B"
            [0, 1] "C" [1, 1] "D"
            */
            var arrBefore = tableSpansExtension.ToArray(tableNode);

            /*
            arrAfter:
            [0, 0] "A" [1, 0] "A" [2, 0] "B"
            [0, 1] "C" [1, 1] "D" [2, 1] "B"
            */
            var arrAfter = tableSpansExtension.ToArray(newTableNode);


            Console.WriteLine("htmlTableNodeBefore:");
            Console.WriteLine(htmlTableNodeBefore);
            Console.WriteLine();

            Console.WriteLine("htmlTableNodeAfter:");
            Console.WriteLine(htmlTableNodeAfter);
            Console.WriteLine();

            Console.WriteLine("arrBefore:");
            PrintArray(arrBefore);
            Console.WriteLine();

            Console.WriteLine("arrAfter:");
            PrintArray(arrAfter);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
```

The table before being processed:

```html
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
```

The table after being processed.

```html
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
```

## ToArray

The data array before being processed:

```csharp
/*    
[0, 0] "A"  [0, 1] "C"
[1, 0] "B"  [1, 1] "D"
*/
var arrBefore = tableSpansExtension.ToArray(tableNode);
```

The data array after being processed:

```csharp
/*
[0, 0] "A"  [1, 0] "A"  [2, 0] "B"
[0, 1] "C"  [1, 1] "D"  [2, 1] "B"
*/
var arrAfter = tableSpansExtension.ToArray(newTableNode);
```

## Credits

Example table found here: https://stackoverflow.com/questions/16693349/complicated-table-using-rowspan-and-colspan