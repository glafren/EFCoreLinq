using Northwind.Data.Models;
using Northwind.Models;
using System.Numerics;
using System.Runtime.Versioning;

namespace Northwind
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NorthwindContext db = new NorthwindContext();

			/*#region  Bütün Employelerin ad ve soyadlarını yazdıran döngü
			var result = db.Employees.ToList();
			foreach ( var employee in result ) 
			{
				Console.WriteLine( employee.FirstName + " " + employee.LastName );	
			}
			#endregion*/

			/*#region  kategorileri ad ve açıklamasını ada göre sıralayıp yazdıran döngü
			var result = db.Categories.Select(c => new {c.CategoryName, c.Description}).OrderBy(c => c.CategoryName).ToList();
			//var result = db.Categories.OrderBy(c => c.CategoryName).ToList();
			foreach (var category in result)
			{
				Console.WriteLine(category.CategoryName + " " + category.Description );
			}
			#endregion*/

			/*#region  Select ContactName, CompanyName, ContactTitle, and Phone from the Customers table sorted by Phone.
			var result = db.Customers.Select(c => new { c.ContactName, c.CompanyName, c.ContactTitle, c.Phone }).OrderBy(c => c.Phone).ToList();
			
			foreach (var customer in result)
			{
				Console.WriteLine(customer.ContactTitle + " | " + customer.CompanyName + " | " + customer.ContactTitle + " | " + customer.Phone );
			}
			#endregion*/

			/*#region  Çalışanların ad ve soyadlarını ve işe alım tarihlerini en yeniden en eskiye doğru sıralanmış olarak gösteren bir sorgu oluşturun.
			var result = db.Employees.Select(e => new { e.FirstName, e.LastName, e.HireDate}).OrderByDescending(e => e.HireDate).ToList();

			foreach (var employee in result)
			{
				Console.WriteLine(employee.FirstName + " | " + employee.LastName + " | " + employee.HireDate);
			}
			#endregion*/


			/* #region  Northwind'in Navlun'a göre en pahalıdan en ucuza doğru sıralanmış siparişlerini gösteren bir rapor oluşturun. Show OrderID, OrderDate, ShippedDate, CustomerID, and Freight.
			var result = db.Orders.Select(o => new { o.OrderId, o.OrderDate, o.ShippedDate, o.CustomerId, o.Freight}).OrderByDescending(o=> o.Freight).ToList();

			foreach (var order in result)
			{
				Console.WriteLine(order.OrderId + " | " + order.OrderDate + " | " + order.ShippedDate + " | " + order.CustomerId + " | " + order.Freight);
			}
			#endregion */

			#region  Select CompanyName, Fax, Phone, HomePage and Country from the Suppliers table sorted by Count in descendin order and then b Com an Name in ascendin order.
			var result = db.Suppliers.Select(s => new { s.CompanyName, s.Fax, s.Phone, s.HomePage, s.Country}).OrderByDescending(s => s.Country).OrderBy(s=>s.CompanyName).ToList();

			foreach (var supplier in result)
			{
                //Console.WriteLine(supplier);
                Console.WriteLine(supplier.CompanyName + " | " + supplier.Fax+ " | " + supplier.Phone + " | " + supplier.HomePage+ " | " + supplier.Country);
            }
			#endregion
		}
	}
}