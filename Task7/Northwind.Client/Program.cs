using System;
using System.Configuration;
using System.Linq;
using Northwind.DAL;
using Northwind.DAL.Entities;

namespace Northwind.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var repository = new DapperRepository(ConfigurationManager.ConnectionStrings["Samples"].ConnectionString);
            INorthwindRepository repository = new AdoNetRepository(ConfigurationManager.ConnectionStrings["Samples"].ConnectionString);

            //GetOrders
            var orders = repository.GetOrders().ToList();
            //foreach (var order in orders)
            //{
            //    Console.WriteLine(
            //        $"ID {order.OrderID} State {order.OrderStatus} OrderDate {order.OrderDate} ShippedDate {order.ShippedDate}");
            //}

            //GetOrdersDetails
            foreach (var detail in repository.GetOrdersDetails())
            {
                Console.WriteLine(
                    $"OrderId {detail.Order.OrderID} OrderStatus {detail.Order.OrderStatus} ProductId {detail.Product.ProductID} ProductName {detail.Product.ProductName} Detail:Price {detail.UnitPrice}");
            }

            //GetOrderDetails
            //var orderDetail = repository.GetOrderDetails(orders.FirstOrDefault().OrderID);
            //Console.WriteLine(
            //    $"OrderId {orderDetail.Order.OrderID} OrderStatus {orderDetail.Order.OrderStatus} ProductId {orderDetail.Product.ProductID} ProductName {orderDetail.Product.ProductName} Detail:Price {orderDetail.UnitPrice}");

            //CreateOrder
            //var newWorldOrder = new OrderForInsert()
            //{
            //    CustomerID = orders.FirstOrDefault().CustomerID,
            //    EmployeeID = orders.FirstOrDefault().EmployeeID,
            //    OrderDate = DateTime.Now
            //};
            //repository.CreateOrder(newWorldOrder);
            //var checkOrder =
            //    repository.GetOrders().OrderByDescending(o => o.OrderDate).FirstOrDefault(o => o.OrderDate != null);
            //Console.WriteLine(
            //    $"ID {checkOrder.OrderID} State {checkOrder.OrderStatus} OrderDate {checkOrder.OrderDate} ShippedDate {checkOrder.ShippedDate}");

            ////Delete2017YearOrders
            //Console.WriteLine($"Orders deleted: {repository.Delete2017YearOrders()}");
            //Console.WriteLine(repository.GetOrders().FirstOrDefault(o => o.OrderDate.Value.Year == 2017) == null
            //    ? "No orders"
            //    : "Has orders");

        }
    }
}
