using Microsoft.EntityFrameworkCore;
using Northwind.Data.Models;
using Northwind.Models;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.Versioning;
using System.Security.Cryptography;
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
			var result = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 5, 19)).Select(o => new { o.OrderDate, o.ShippedDate, o.CustomerId, o.Freight }).ToList();

			foreach (var order in result) 
			{
				Console.WriteLine(order.OrderDate + " " + order.ShippedDate + " " + order.CustomerId + " " + order.Freight);
            }
			*/
            #endregion

            #region 9- Create a report showing the first name, last name, and country of all employees not in the United States.
            /*
			var result = db.Employees.Where(e => e.Country != "USA").Select(e => new { e.FirstName, e.LastName, e.Country }).ToList();
			
			foreach (var employee in result)
			{
				Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Country);
            }
			*/
            #endregion
            #region 10- Create a report that shows the employee id, order id, customer id, required date, and shipped date of all orders that were shipped later than the were required.
            /*
			var result = db.Orders.Where(o => o.ShippedDate > o.RequiredDate).Select(o => new { o.EmployeeId, o.OrderId, o.CustomerId, o.RequiredDate, o.ShippedDate }).ToList();
			foreach(var order in result)
			{
				Console.WriteLine(order.EmployeeId + " " + order.OrderId + " " + order.CustomerId + " " + order.RequiredDate + " " + order.ShippedDate);
            }
			*/
            #endregion
            #region 11- Create a report that shows the City, company name, and contact name of all customers who are in cities that be 'n with "A” or "B.”
            /*
			var result = db.Customers.Where(c => c.City.StartsWith("A") || c.City.StartsWith("B")).Select(c => new { c.City, c.CompanyName, c.ContactName }).ToList();
			foreach(var customer in result)
			{
				Console.WriteLine(customer.City + " " + customer.CompanyName + " " + customer.ContactName);	
			}
			*/
            #endregion

            #region 12- Create a report that shows all orders that have a freight cost of more than 500.00.
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
			var result = db.Products.Where(p => p.ReorderLevel >= p.UnitsInStock).Select(p => new { p.ProductName, p.UnitsInStock, p.UnitsOnOrder, p.ReorderLevel }).ToList();
			foreach ( var product in result )
			{
				Console.WriteLine(product.ProductName+" "+product.UnitsInStock+" "+product.UnitsOnOrder+" "+product.ReorderLevel);
			}
			*/
            #endregion

            #region 14- Create a report that shows the company name, contact name and fax number of all customers that have a fax number.
            /*
			var result = db.Customers.Where(c => c.Fax != null).Select(c => new { c.CompanyName, c.ContactName, c.Fax }).ToList();
			foreach ( var c in result ) 
			{
                Console.WriteLine(c.CompanyName+" "+c.ContactName+" "+c.Fax);
            }
			*/
            #endregion

            #region 15- Create a report that shows the fırst and last name of all employees who do not report to anybody
            /*
			var result = db.Employees.Where(e => e.ReportsTo == null).Select(e => new { e.FirstName, e.LastName, e.ReportsTo }).ToList();
			foreach ( var e in result ) 
			{
                Console.WriteLine(e.FirstName +" "+ e.LastName);
            }
			*/
            #endregion
            #region 16- Create a report that shows the company name, contact name and fax number of all customers that have a fax number. Sort by company name.
            /*
			var result = db.Customers.Where(c => c.Fax != null).Select(c => new { c.CompanyName, c.ContactName, c.Fax }).OrderBy(c=> c.CompanyName).ToList();
			foreach ( var c in result ) 
			{
                Console.WriteLine(c.CompanyName+" "+c.ContactName+" "+c.Fax);
            }
			*/
            #endregion
            #region 17- Create a report that shows the City, company name, and contact name of all customers who are in cities that be 'n with "A” or "B.”.Sort by contact name in descending order
            /*
			var result = db.Customers.Where(c => c.City.StartsWith("A") || c.City.StartsWith("B")).Select(c => new { c.City, c.CompanyName, c.ContactName }).OrderByDescending(c=> c.ContactName).ToList();
			foreach (var customer in result)
			{
				Console.WriteLine(customer.City + " " + customer.CompanyName + " " + customer.ContactName);
			}
			*/
            #endregion
            #region 18- Create a report that shows the first and last names and birth date of all employees born in the 1950s.
            /*
			var date = new DateTime(1950, 01, 01);
			var result = db.Employees.Where(e => e.BirthDate.Value.Year >= 1950 && e.BirthDate.Value.Year <= 1960).Select(e => new { e.FirstName, e.LastName, e.BirthDate }).ToList();

			foreach ( var e in result ) 
			{
				Console.WriteLine(e.FirstName + " " + e.LastName + " " + e.BirthDate);
            }
			*/
            #endregion
            #region 19- Create a report that shows the product name and supplier id for all products supplied by Exotic Liquids, Grandma Kelly's Homestead, and Tokyo Traders.
            /*
			
			List<string> list = new List<string>();
			list.Add("Tokyo Traders");
			list.Add("Exotic Liquids");
			list.Add("Grandma Kelly's Homestead");

			var result = db.Products.Where(p =>
			db.Suppliers.Where(s => list.Contains(s.CompanyName)).
			Select(s => s.SupplierId).
			Contains((int)p.SupplierId)).Select(p => new Product
			{
				ProductName = p.ProductName,
				SupplierId = p.SupplierId,

			});*/
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
            #region 25- Create a report that shows the units in stock, unit price, the total price value of all units in stock, the total price value of all unitsin Stock rounded down, and the total price value of all units in Stock rounded up. Sort the total price value descending.
            /*
			var result = db.Products.Select(p => new
			{
				p.UnitsInStock,
				p.UnitPrice,
				TotalPrice = (p.UnitPrice * p.UnitsInStock),
				TotalPriceDown = Math.Floor((decimal)p.UnitPrice * (short)p.UnitsInStock),
				TotalPriceUp = Math.Ceiling((decimal)p.UnitPrice * (short)p.UnitsInStock)
			}).OrderByDescending(p=>p.TotalPrice).ToList();
			foreach (var item in result)
			{
                Console.WriteLine(item.UnitPrice + " " + item.UnitsInStock + " " + item.TotalPrice + " | " + item.TotalPriceDown + " | " + item.TotalPriceUp );
            }
			*/
            #endregion
            #region 26- SQL SERVER AND MYSQL USERS ONLY: ın an earlier demo, you saw a report that returned the age of each employee when hired. That report was not entirely accurate as it didn't account for the month and day the employee was born.Fix that report, showing both the original(inaccurate) hire age and the actual hire age.The result Will look like this.
            /*
			var result = db.Employees.Select(e=> new { HireAgeAccurate = ((e.HireDate - e.BirthDate).Value.Days)/365.0,
			HireAgeInaccurate = e.HireDate.Value.Year - e.BirthDate.Value.Year } ).ToList();

			foreach ( var e in result ) 
			{
                Console.WriteLine((e.HireAgeAccurate)+" "+e.HireAgeInaccurate);
            }
			*/
            #endregion
            #region 27-Create a report that shows the fırst and last names and birth month (as a string) for each employee born in the current month.
            /*
			var result = db.Employees.Where(e => e.BirthDate.Value.Month == DateTime.Now.Month).
			Select(e => new{e.FirstName,e.LastName, MounthName= e.BirthDate.Value.ToString("MMMM")}).ToList();

			foreach ( var e in result ) 
			{
                Console.WriteLine(e.FirstName + " " +e.LastName+ " " + e.MounthName);
            }
			*/
            #endregion

            #region 28- Create a report that shows the contact title in all Iowercase letters of each customer contact.
            /*
			var result = db.Customers.Select(c => c.ContactName.ToLower()).ToList();

			foreach ( var customer in result ) 
			{
                Console.WriteLine(customer);
            }
			*/
            #endregion

            #region 30- Create a report that shows all products by name that are in the Seafood category
            /*
			var result = db.Products.Include(c => c.Category).Where(c => c.Category.CategoryName == "Seafood");

			foreach (var product in result)
			{
				Console.WriteLine(product.ProductName + " "+product.CategoryId + " " + product.Category.CategoryName);
			}
			*/
            #endregion

            #region 31- Create a report that shows all companies by name that sell products in CategoryID 8.
            /*
			var result = db.Products.Where(p => p.CategoryId == 8).ToList();
			foreach (var product in result) 
			{
				Console.WriteLine(product.CategoryId+ " " +product.ProductName);
			}
			*/
            #endregion

            #region 32- Create a report that shows all companies by name that sell products in the Seafood category.
            /*
			var result = db.Products.Include(p => p.Category).Where(c => c.Category.CategoryName == "Seafood").Select(c => c.ProductName).ToList();
			foreach ( var item in result ) 
			{
				Console.WriteLine(item);
			}
			*/
            #endregion
            #region 33- Create a report that shows the order ids and the associated employee names for orders that shipped after the required date.It should return the following.There should be 37 rows returned.

            /*
			select FirstName, Orders.OrderID from Employees
			join Orders on Employees.EmployeeID = Orders.EmployeeID
			where Orders.ShippedDate > Orders.RequiredDate
			*/

            //var result = db.Orders.Include(o => o.Employee).Where(o => o.ShippedDate > o.RequiredDate).Select(o => new { o.EmployeeId, o.Employee.FirstName }).ToList();
            /*
			var result = db.Orders.Where(o => o.ShippedDate > o.RequiredDate).Join(db.Employees, o => o.EmployeeId, e => e.EmployeeId, (order, employee) => new
			{
				order.OrderId,
				employee.FirstName,
				employee.LastName
			});



			//Console.WriteLine(result.Count);
			Console.WriteLine("Toplam Sayı:" + result.Count(a => true)); //IQueryable da kullanılabilir. 
            foreach ( var o in result ) 
			{
                Console.WriteLine(o.OrderId + " " + o.FirstName + " " + o.LastName);
            }
			*/
            #endregion

            #region 34- Create a report that shows the total quantity of products (from the Order_DetaiIs table) ordered. Only Show records for products for which the quantity ordered is fewer than 200.The report should return the following 5 rows.

            /*
				SELECT p.ProductName, SUM(o.Quantity) as TotalUnits
				FROM [Order Details] o
				JOIN Products p ON o.ProductID = p.ProductID
				GROUP BY p.ProductName
				having SUM(o.Quantity) < 200 
			 */
            /*
		   var result = db.OrderDetails.Join(db.Products, od => od.ProductId, p => p.ProductId, (orderdetail, product) => new {
			   orderdetail.Quantity,
			   product.ProductName
		   })
		   .GroupBy(g => g.ProductName)
		   .Where(g => g.Sum(x => x.Quantity) < 200)
		   .Select(s => new {
			   ProductName = s.Key,
			   TotalUnits = s.Sum(x => x.Quantity)
		   });

		   foreach (var item in result)
		   {
			   Console.WriteLine(item.ProductName + " " + item.TotalUnits);
		   }
		   */
            #endregion

            #region 35- Create a report that shows the total number of orders by Customer since December 31, 1996. The report should only return rows for which the NumOrders is greater than 15.The report should return the following 5 rows.

            /*
			select c.CompanyName, count(o.OrderID) as NumOrders from Orders o
			join Customers c on o.CustomerID = c.CustomerID
			where o.OrderDate > '12/31/1996'
			group by c.CompanyName
			having count(o.OrderID) > 15
			 */

            /*
		   var result = db.Orders.Include(o => o.Customer)
		   .Where(g=> g.OrderDate > new DateTime(1996,12,31))
		   .GroupBy(g => g.Customer.CompanyName)
		   .Where(g => g.Count() > 15)
		   .Select(g => new
		   {
			   companyname = g.Key,
			   numorders = g.Count(g => true)
		   });
		   */
            /*
			 var result = db.Customers.GroupJoin(db.Orders.Where(x => x.OrderDate > new DateTime(1996, 12, 31)), c => c.CustomerId, o => o.CustomerId, (customer, gruplanmisOrderTablosu) => new
			 {
				 customer.CompanyName,
				 OrderCount = gruplanmisOrderTablosu.Count()
			 }).Where(res => res.OrderCount > 15);


			 foreach (var item in result) 
			 {
				 Console.WriteLine(item.OrderCount + " " + item.CompanyName);
			 }
			 */
            #endregion

            #region 36- Create a report that shows the company name, order id, and total price of ali products of which Northwind has sold more than 10,000 worth.There is no need for a GROUP BY clause in this report.

            /*
				select c.CompanyName, o.OrderID, ((od.Quantity * od.UnitPrice)*(1-od.Discount)) as TotalPrice  from Customers c 
				join Orders o on o.CustomerID = c.CustomerID 
				join [Order Details] od on od.OrderID = o.OrderID
				where ((od.Quantity * od.UnitPrice)*(1-od.Discount)) >= 10000
			 */
            /*
		   var result = db.OrderDetails.Include(c => c.Order).ThenInclude(o => o.Customer)
		   .Where(c => (c.Quantity * c.UnitPrice) * (1 - (decimal)c.Discount) >= 10000)
		   .Select(res => new
		   {
			   res.Order.Customer.CompanyName,
			   res.OrderId,
			   TotalPrice = (res.Quantity * res.UnitPrice) * (1 - (decimal)res.Discount)
		   });

		   foreach (var item in result) 
		   {
			   Console.WriteLine(item.CompanyName + " " + item.OrderId + " " + item.TotalPrice);
		   }*/
            #endregion
            Console.WriteLine(RandomStringGenerater(5));
            
		}
		static string RandomStringGenerater(int length)
		{
			//Bu metodun amacı, girilen uzunluk değeri kadar uzun bir rastgele string oluşturmaktır.
			//stringi oluştururken, Büyükharf, Küçükarf ve Rakam kullanılacaktır.
			//Ancak içerisinde kaç büyükharf kaç küçük harf ve kaç rakam olacağı RASTGELE olarak belirlenecektir.
			//Ama, en az bir büyük harf, en az bir küçük harf ve en az bir rakam olması, garanti edilecektir.
			/*
			Random random = new Random();
			string words = "abcdefghıijklmnopqrstuvwxyz";
			string password = "";
			int numCount = random.Next(1, length / 2);
			for (int i = 0; i < length - numCount; i++)
			{
				int durum = random.Next(1, 3);

				if (durum == 1) // büyük harf
				{
					string UpperCase = words[random.Next(0, words.Length)].ToString().ToUpper();
					password += UpperCase;
				}
				else if (durum == 2) // küçük harf
				{
					string LowerCase = words[random.Next(0, words.Length)].ToString().ToLower();
					password += LowerCase;
				}
			}
			for (int j = 0; j < numCount; j++)
			{
				string number = random.Next(0, 10).ToString();//sayı
				password = password.Insert(random.Next(0, password.Length), number);
			}
			return password ;
			*/

			Random rnd = new Random();
				string karakterler = "ag4567hijklmnoprstuvyzx1238bcdef90QWERTYUIOPASDFGHJKLZXCVBNM";
				string randomString = "";
				if (length >= 3)
				{
					for (int i = 0; i < length - 3; i++)
					randomString += karakterler[rnd.Next(0, karakterler.Length)];

					//bir tane küçük harf enjekte edelim.
					randomString = randomString.Insert(rnd.Next(0, randomString.Length), Convert.ToChar(rnd.Next(97, 123)).ToString());

					//bir tane de büyük harf enjekte edelim

					randomString = randomString.Insert(rnd.Next(0, randomString.Length), Convert.ToChar(rnd.Next(65, 91)).ToString());

					//bir tane de rakam enjekte edelim

					randomString = randomString.Insert(rnd.Next(0, randomString.Length), rnd.Next(0, 10).ToString());
				}
				return randomString;
		}

	}
}