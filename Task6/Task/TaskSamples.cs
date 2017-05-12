using System;
using System.Collections.Generic;
using System.Linq;
using Task.Data;

namespace Task
{
    [Title("LINQ Module tasks")]
    [Prefix("Linq")]
    class TaskSamples : SampleHarness
    {
        private readonly DataSource _dataSource = new DataSource();

        [Category("Hometask")]
        [Title("Task 1")]
        [Description("Выдайте список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X")]
        public void Linq1()
        {
            var x = 20000m;

            var clients = _dataSource.Customers.Where(c => c.Orders.Sum(o => o.Total) > x);

            foreach (var client in clients)
                Console.WriteLine($"Name \"{client.CompanyName}\" SUM \"{client.Orders.Sum(o => o.Total)}\"");
        }

        [Category("Hometask")]
        [Title("Task 2")]
        [Description("Для каждого клиента составьте список поставщиков, находящихся в той же стране и том же городе")]
        public void Linq2()
        {
            // Сделайте задания с использованием группировки и без.
            var map = new Dictionary<Customer, IEnumerable<Supplier>>();
            foreach (var client in _dataSource.Customers)
            {
                var suppliers = _dataSource.Suppliers.Where(s => s.Country == client.Country && s.City == client.City).ToList();
                if (suppliers.Any())
                    map[client] = suppliers;
            }
            foreach (var client in map.Keys)
            {
                Console.WriteLine($"Customer: Name \"{client.CompanyName}\" Country \"{client.Country}\" City \"{client.City}\"");
                foreach (var supplier in map[client])
                    Console.WriteLine($"Supplier: Name \"{supplier.SupplierName}\" Country \"{supplier.Country}\" City \"{supplier.City}\"");
            }
        }

        [Category("Hometask")]
        [Title("Task 3")]
        [Description("Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X")]
        public void Linq3()
        {
            var x = 5000m;

            var clients = _dataSource.Customers.Where(c => c.Orders.Any(o => o.Total > x));

            foreach (var client in clients)
                Console.WriteLine($"Name \"{client.CompanyName}\" Order total \"{client.Orders.FirstOrDefault(o => o.Total > x)?.Total}\"");
        }

        [Category("Hometask")]
        [Title("Task 4")]
        [Description("Выдайте список клиентов с указанием, начиная с какого месяца какого года они стали клиентами")]
        public void Linq4()
        {
            foreach (var client in _dataSource.Customers.Where(c => c.Orders.Any()))
                Console.WriteLine($"Start date \"{client.Orders.Min(o=>o.OrderDate):yyyy.MM.dd}\" Name \"{client.CompanyName}\"");
        }

        [Category("Hometask")]
        [Title("Task 5")]
        [Description("Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу, оборотам клиента (от максимального к минимальному) и имени клиента")]
        public void Linq5()
        {
            Console.WriteLine("Sorted by date:");
            var ordered1 =
                from client in _dataSource.Customers
                where client.Orders.Any()
                orderby client.Orders.Min(o => o.OrderDate)
                select client;
            foreach (var client in ordered1)
                Console.WriteLine($"Start date \"{client.Orders.Min(o=>o.OrderDate):yyyy.MM.dd}\" Name \"{client.CompanyName}\"");

            Console.WriteLine();
            Console.WriteLine("Sorted by count:");
            var ordered2 =
                from client in _dataSource.Customers
                where client.Orders.Any()
                orderby client.Orders.Length descending
                select client;
            foreach (var client in ordered2)
                Console.WriteLine($"Start date \"{client.Orders.Min(o => o.OrderDate):yyyy.MM.dd}\" Orders \"{client.Orders.Length}\" Name \"{client.CompanyName}\"");

            Console.WriteLine();
            Console.WriteLine("Sorted by name:");
            var ordered3 =
                from client in _dataSource.Customers
                where client.Orders.Any()
                orderby client.CompanyName
                select client;
            foreach (var client in ordered3)
                Console.WriteLine($"Name \"{client.CompanyName}\" Start date \"{client.Orders.Min(o => o.OrderDate):yyyy.MM.dd}\"");
        }

        [Category("Hometask")]
        [Title("Task 6")]
        [Description("Укажите всех клиентов, у которых указан нецифровой почтовый код или не заполнен регион или в телефоне не указан код оператора")]
        public void Linq6()
        {
            var badClients =
                from client in _dataSource.Customers
                where string.IsNullOrEmpty(client.PostalCode) ||
                      !client.PostalCode.ToCharArray().All(char.IsDigit) ||
                      string.IsNullOrEmpty(client.Region) ||
                      client.Phone[0] != '('
                select client;

            foreach (var client in badClients)
                Console.WriteLine(
                    $"Name \"{client.CompanyName}\" PCode \"{client.PostalCode ?? "null"}\" Region \"{client.Region ?? "null"}\" Phone \"{client.Phone}\"");
        }

        [Category("Hometask")]
        [Title("Task 7")]
        [Description("Cгруппируйте все продукты по категориям, внутри – по наличию на складе, внутри последней группы отсортируйте по стоимости")]
        public void Linq7()
        {
            var products =
                from product in _dataSource.Products
                group product by product.Category
                into g1
                select new
                {
                    Category = g1.Key,
                    Products = from product in g1
                    group product by product.UnitsInStock > 0
                    into g2
                    select new
                    {
                        InStock = g2.Key,
                        Products = from product in g2
                        group product by product.UnitPrice
                        into g3
                        select new
                        {
                            Price = g3.Key,
                            Products = g3.ToList()
                        }
                    }
                };
            foreach (var group1 in products)
            {
                Console.WriteLine($"Category \"{group1.Category}\"");
                foreach (var group2 in group1.Products)
                {
                    Console.WriteLine($" In stock \"{group2.InStock}\"");
                    foreach (var group3 in group2.Products)
                    {
                        Console.WriteLine($"  Price \"{group3.Price}\"");
                        foreach (var product in group3.Products)
                        {
                            Console.WriteLine($"   Product \"{product.ProductName}\"");
                        }
                    }
                }
            }
        }
    }
}
