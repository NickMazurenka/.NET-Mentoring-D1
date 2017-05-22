using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperExample;

namespace Northwind.DAL
{
    class Program
    {
        protected static string ConnectionString;
        static void Main(string[] args)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Samples"].ConnectionString;

            Query1();
            Query2();
            Query3();
            Query4();
            Query5();

            Console.ReadLine();
        }

        static void Query5()
        {
            Console.WriteLine("SP");
            using (var con = new SqlConnection(ConnectionString))
            {
                var products = con.Query<ExpensiveProduct>("[Northwind].[Ten Most Expensive Products]", commandType: CommandType.StoredProcedure).ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.TenMostExpensiveProducts + " " + product.UnitPrice);
                }
            }
            Console.WriteLine();
        }

        static void Query4()
        {
            Console.WriteLine("Execute");
            using (var con = new SqlConnection(ConnectionString))
            {
                int rowsAffected = con.Execute("SELECT * FROM Northwind.Products");
                Console.WriteLine("Rows affected " + rowsAffected);
            }
            Console.WriteLine();
        }

        static void Query3()
        {
            Console.WriteLine("Product by id");
            int id = 5;
            using (var con = new SqlConnection(ConnectionString))
            {
                var product = con.Query<Product>("SELECT * FROM Northwind.Products WHERE ProductId = @Id", new { id }).Single();
                Console.WriteLine(product.ProductId + " " + product.ProductName);
            }
            Console.WriteLine();
        }

        static void Query2()
        {
            Console.WriteLine("One Customer");
            using (var con = new SqlConnection(ConnectionString))
            {
                var customer = con.Query<Customer>("SELECT TOP 1 * FROM Northwind.Customers").Single();
                Console.WriteLine(customer.CustomerId + " " + customer.ContactName + " " + customer.JoinDate);
            }
            Console.WriteLine();
        }

        static void Query1()
        {
            Console.WriteLine("TOP 5 products");
            using (var con = new SqlConnection(ConnectionString))
            {
                var products = con.Query<Product>("SELECT TOP 5 * FROM Northwind.Products").ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductId + " " + product.ProductName + " " + product.Discontinued);
                }
            }
            Console.WriteLine();
        }
    }
}