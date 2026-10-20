// See https://aka.ms/new-console-template for more information
using LINQ.DataSources;
using LINQ.Models;
var ProductList = Source.ProductList;
var CustomerList = Source.CustomerList;
// 1. Seafood
var seafood = ProductList.Where(p => p.Category == "Seafood");
foreach (var p in seafood)
    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

// 2. Names only
var names = ProductList.Select(p => p.ProductName);
foreach (var n in names) Console.WriteLine(n);

// 3. Sort by UnitPrice ascending
var byPrice = ProductList.OrderBy(p => p.UnitPrice);
foreach (var p in byPrice)
    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

// 4. Price between 10 and 30
var mid = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

// 5. In stock + Condiments
var cond = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

// 6. Anonymous type
var result = ProductList.Select(p => new
{
    Name = p.ProductName,
    Price = p.UnitPrice,
    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
});
foreach (var r in result)
    Console.WriteLine($"{r.Name} - {r.Price} - {r.StockStatus}");

// 7 & 11. Position (1-based) with name
var indexed = ProductList.Select((p, i) => new { Pos = i + 1, p.ProductName });
foreach (var x in indexed)
    Console.WriteLine($"{x.Pos}. {x.ProductName}");

// 8. Category asc, then UnitPrice desc
var sorted = ProductList
    .OrderBy(p => p.Category)
    .ThenByDescending(p => p.UnitPrice);

// 9. Beverages sorted by stock desc
var bev = ProductList
    .Where(p => p.Category == "Beverages")
    .OrderByDescending(p => p.UnitsInStock);
foreach (var p in bev)
    Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

// 10. Query syntax, compound from
var orders = from c in CustomerList
             from o in c.Orders
             where o.OrderDate.Year >= 1997
             select new { c.CustomerID, o.OrderDate };
foreach (var o in orders)
    Console.WriteLine($"{o.CustomerID} - {o.OrderDate}");

// 12. Length first, then case-insensitive
string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
var words = Arr
    .OrderBy(w => w.Length)
    .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
foreach (var w in words) Console.WriteLine(w);

// 13. Digits whose second letter is 'i', in reverse order
string[] digits = { "zero", "one", "two", "three", "four",
                    "five", "six", "seven", "eight", "nine" };
var rev = digits.Where(d => d[1] == 'i').Reverse().ToList();
foreach (var d in rev) Console.WriteLine(d);
// nine, eight, six, five

