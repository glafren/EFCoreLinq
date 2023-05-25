using Microsoft.EntityFrameworkCore;
using Northwind.Data.Models;
using Northwind.Models;
using System;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.Versioning;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Northwind
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NorthwindContext db = new NorthwindContext();

			#region 1- Bütün Employelerin ad ve soyadlarını yazdıran döngü
			/*
			var result = db.Employees.ToList();
			foreach ( var employee in result ) 
			{
				Console.WriteLine( employee.FirstName + " " + employee.LastName );	
			}
			*/
			#endregion

			#region 2- kategorileri ad ve açıklamasını ada göre sıralayıp yazdıran döngü
			/*
			var result = db.Categories.Select(c => new {c.CategoryName, c.Description}).OrderBy(c => c.CategoryName).ToList();
			//var result = db.Categories.OrderBy(c => c.CategoryName).ToList();
			foreach (var category in result)
			{
				Console.WriteLine(category.CategoryName + " " + category.Description );
			}
			*/
			#endregion

			#region 3- Select ContactName, CompanyName, ContactTitle, and Phone from the Customers table sorted by Phone.
			/*
			var result = db.Customers.Select(c => new { c.ContactName, c.CompanyName, c.ContactTitle, c.Phone }).OrderBy(c => c.Phone).ToList();
			foreach (var customer in result)
			{
				Console.WriteLine(customer.ContactTitle + " | " + customer.CompanyName + " | " + customer.ContactTitle + " | " + customer.Phone );
			}
			*/
			#endregion

			#region 4- Çalışanların ad ve soyadlarını ve işe alım tarihlerini en yeniden en eskiye doğru sıralanmış olarak gösteren bir sorgu oluşturun.
			/*
			var result = db.Employees.Select(e => new { e.FirstName, e.LastName, e.HireDate}).OrderByDescending(e => e.HireDate).ToList();
			foreach (var employee in result)
			{
				Console.WriteLine(employee.FirstName + " | " + employee.LastName + " | " + employee.HireDate);
			}
			*/
			#endregion

			#region 5- Northwind'in Navlun'a göre en pahalıdan en ucuza doğru sıralanmış siparişlerini gösteren bir rapor oluşturun. Show OrderID, OrderDate, ShippedDate, CustomerID, and Freight.
			/*
			var result = db.Orders.Select(o => new { o.OrderId, o.OrderDate, o.ShippedDate, o.CustomerId, o.Freight}).OrderByDescending(o=> o.Freight).ToList();
			foreach (var order in result)
			{
				Console.WriteLine(order.OrderId + " | " + order.OrderDate + " | " + order.ShippedDate + " | " + order.CustomerId + " | " + order.Freight);
			}
			*/
			#endregion

			#region 6- Select CompanyName, Fax, Phone, HomePage and Country from the Suppliers table sorted by Count in descendin order and then b Com an Name in ascendin order.
			/*
			var result = db.Suppliers.Select(s => new { s.CompanyName, s.Fax, s.Phone, s.HomePage, s.Country}).OrderByDescending(s => s.Country).OrderBy(s=>s.CompanyName).ToList();
			foreach (var supplier in result)
			{
                //Console.WriteLine(supplier);
                Console.WriteLine(supplier.CompanyName + " | " + supplier.Fax+ " | " + supplier.Phone + " | " + supplier.HomePage+ " | " + supplier.Country);
            }
			*/
			#endregion

			#region 7- Create a report showing all the company names and contact names of Northwind's customers in Buenos Aires.
			/*
			var result = db.Customers.Select(c => new { c.CompanyName, c.ContactName,c.City }).Where(s => s.City == "Buenos Aires").ToList(); 
			foreach(var customer in result)
			{
                Console.WriteLine(customer.CompanyName + " | " + customer.ContactName);
            }
			*/
			#endregion

			#region 8- Create a report showing the order date, shipped date, customer id, and freight of all orders placed on May 19, 1997.
			/*
			var date = new DateTime(1997, 05, 19);
			var result = db.Orders.Select(o => new { o.OrderDate, o.ShippedDate, o.CustomerId, o.Freight }).Where(o => o.OrderDate == date).ToList();

			foreach (var order in result) 
			{
				Console.WriteLine(order.OrderDate + " " + order.ShippedDate + " " + order.CustomerId + " " + order.Freight);
            }
			*/
			#endregion

			#region 9- Create a report showing the first name, last name, and country of all employees not in the United States.
			/*
			var result = db.Employees.Select(e => new { e.FirstName, e.LastName, e.Country }).Where(e => e.Country != "USA").ToList();
			
			foreach (var employee in result)
			{
				Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Country);
            }
			*/
			#endregion

			#region 10- Create a report that shows the employee id, order id, customer id, required date, and shipped date of all orders that were shi ed later than the were re uired.
			/*
			var result = db.Orders.Select(o => new { o.EmployeeId, o.OrderId, o.CustomerId, o.RequiredDate, o.ShippedDate }).Where(o => o.ShippedDate > o.RequiredDate).ToList();
			foreach(var order in result)
			{
				Console.WriteLine(order.EmployeeId + " " + order.OrderId + " " + order.CustomerId + " " + order.RequiredDate + " " + order.ShippedDate);
            }
			*/
			#endregion

			#region 11- Create a report that shows the City, company name, and contact name of all customers who are in cities that be 'n with "A” or "B.”
			/*
			var result = db.Customers.Select(c => new { c.City, c.CompanyName, c.ContactName }).Where(c => c.City.StartsWith ("A") || c.City.StartsWith("B")).ToList();
			foreach(var customer in result)
			{
				Console.WriteLine(customer.City + " " + customer.CompanyName + " " + customer.ContactName);	
			}
			*/
			#endregion

			#region 12- Create a report that shows all orders that have a freight cost of more than $500.00.
			/*
			var result = db.Orders.Where(o => o.Freight > 500).ToList();
            foreach (var order in result) 
			{
                Console.WriteLine(order.OrderId + " " +order.Freight);
            }
			*/
			#endregion

			#region 13- Create a report that shows the product name, units in Stock, units on order, and reorder level of all products that are up for reorder
			/*
			var result = db.Products.Select(p => new { p.ProductName, p.UnitsInStock, p.UnitsOnOrder, p.ReorderLevel }).Where(p => p.ReorderLevel > 1).ToList();
			foreach ( var product in result )
			{
				Console.WriteLine(product.ProductName+" "+product.UnitsInStock+" "+product.UnitsOnOrder+" "+product.ReorderLevel);
			}
			*/
			#endregion

			#region 14- Create a report that shows the company name, contact name and fax number of all customers that have a fax number.
			/*
			var result = db.Customers.Select(c => new { c.CompanyName, c.ContactName, c.Fax }).Where(c => c.Fax != null).ToList();
			foreach ( var c in result ) 
			{
                Console.WriteLine(c.CompanyName+" "+c.ContactName+" "+c.Fax);
            }
			*/
			#endregion

			#region 15- Create a report that shows the fırst and last name of all employees who do not report to anybody
			/*
			var result = db.Employees.Select(e => new { e.FirstName, e.LastName, e.ReportsTo }).Where(e => e.ReportsTo == null).ToList();
			foreach ( var e in result ) 
			{
                Console.WriteLine(e.FirstName +" "+ e.LastName);
            }
			*/
			#endregion

			#region 16- Create a report that shows the company name, contact name and fax number of all customers that have a fax number. Sort by company name.
			/*
			var result = db.Customers.Select(c => new { c.CompanyName, c.ContactName, c.Fax }).Where(c => c.Fax != null).OrderBy(c=> c.CompanyName).ToList();
			foreach ( var c in result ) 
			{
                Console.WriteLine(c.CompanyName+" "+c.ContactName+" "+c.Fax);
            }
			*/
			#endregion

			#region 17- Create a report that shows the City, company name, and contact name of all customers who are in cities that be 'n with "A” or "B.”.Sort by contact name in descending order
			/*
			var result = db.Customers.Select(c => new { c.City, c.CompanyName, c.ContactName }).Where(c => c.City.StartsWith("A") || c.City.StartsWith("B")).OrderByDescending(c=> c.ContactName).ToList();
			foreach (var customer in result)
			{
				Console.WriteLine(customer.City + " " + customer.CompanyName + " " + customer.ContactName);
			}
			*/
			#endregion

			#region 18- Create a report that shows the first and last names and birth date of all employees born in the 1950s.
			/*
			var date = new DateTime(1950, 01, 01);
			var result = db.Employees.Select(e => new { e.FirstName, e.LastName, e.BirthDate }).Where(e => e.BirthDate >= date).ToList();

			foreach ( var e in result ) 
			{
				Console.WriteLine(e.FirstName + " " + e.LastName + " " + e.BirthDate);
            }
			*/
			#endregion

			#region 19- Create a report that shows the product name and supplier id for all products supplied by Exotic Liquids, Grandma Kelly's Homestead, and Tokyo Traders.
			/*
			var suppliers = db.Suppliers.Where(s => s.CompanyName == "Exotic Liquids" || s.CompanyName == "Grandma Kelly's Homestead" || s.CompanyName == "Tokyo Traders").Select(s=>s.SupplierId).ToList();
			var result = db.Products.Where(s => suppliers.Contains((int)s.SupplierId)).Select(s=> new{s.ProductName,s.SupplierId}).ToList();
			foreach (var product in result)
			{
				Console.WriteLine(product.ProductName + " " +product.SupplierId);
			}
			*/
			#endregion

			#region 20- Create a report that shows the shipping postal code, order id, and order date for all orders with a ship postal code beginning with "02389".
			/*
			var result = db.Orders.Where(o => o.ShipPostalCode.StartsWith("02389")).Select(o => new { o.ShipPostalCode, o.OrderId, o.OrderDate }).ToList();
			foreach (var order in result) 
			{
                Console.WriteLine(order.ShipPostalCode+" "+order.OrderId+" "+ order.OrderDate);
            }
			*/
			#endregion

			#region 21- Create a report that shows the contact name and title and the company name for all customers whose contact title does not contain the word "Sales".
			/*
			var result = db.Customers.Where(c => !c.ContactTitle.Contains("Sales")).Select(c => new { c.ContactName, c.CompanyName,c.ContactTitle }).ToList();
			foreach ( var c in result) 
			{
				Console.WriteLine(c.ContactName + " " + c.CompanyName + "" + c.ContactTitle);
            }
			*/
			#endregion

			#region 22- Create a report that shows the first and last names and cities of employees from cities other than Seattle in the State of Washington.
			/*
			var result = db.Employees.Where(e => e.Region == "WA" && e.City != "Seattle").Select(e => new { e.FirstName, e.LastName, e.City }).ToList();
			foreach ( var e in result ) 
			{
				Console.WriteLine(e.FirstName + " " + e.LastName + " " + e.City);
            }
			*/
			#endregion

			#region 23- Create a report that shows the company name, contact title, City and country of all customers in Mexico or in any City in Spain except Madrid.
			/*
			var result = db.Customers.Where(c => (c.Country == "Mexico" || c.Country == "Spain") && c.City != "Madrid").Select(c=> new{c.CompanyName,c.ContactTitle,c.City,c.Country}).ToList();

			foreach ( var c in result ) 
			{
				Console.WriteLine(c.CompanyName + " " + c.ContactTitle + " " + c.City + " " + c.Country);
            }
			*/
			#endregion

			#region 24- Write a SELECT statement that outputs the following.
			/*
			var result = db.Employees.Select(c => new { ContactInfo = string.Concat(c.FirstName , " " , c.LastName , " can be reached at x" , c.Extension, " .")}).ToList();
            foreach ( var item in result ) 
			{
                Console.WriteLine(item.ContactInfo);
            }
			*/
            #endregion

        }
	}
}