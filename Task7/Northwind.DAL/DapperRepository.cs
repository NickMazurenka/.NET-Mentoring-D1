using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Northwind.DAL.Entities;

namespace Northwind.DAL
{
    public class DapperRepository : INorthwindRepository
    {
        private readonly string _connectionString;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Order> GetOrders()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                return con.Query<Order>("SELECT * FROM Northwind.Orders");
            }
        }

        public IEnumerable<OrderDetail> GetOrdersDetails()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                return con.Query<OrderDetail, Order, Product, OrderDetail>(
                    @"SELECT *
                    FROM Northwind.[Order Details] details
                    JOIN Northwind.Orders orders
                    ON details.OrderId = orders.OrderId
                    JOIN Northwind.Products products
                    ON details.ProductId = products.ProductId",
                    (detail, order, product) =>
                    {
                        detail.Order = order;
                        detail.Product = product;
                        return detail;
                    }, splitOn: "OrderId,ProductId");
            }
        }

        public OrderDetail GetOrderDetails(int orderId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                using (var reader = con.QueryMultiple(
                    @"SELECT *
                    FROM Northwind.[Order Details] details
                    JOIN Northwind.Orders orders
                    ON details.OrderId = orders.OrderId
                    JOIN Northwind.Products products
                    ON details.ProductId = products.ProductId
                    WHERE details.OrderId = @OrderId",
                    new {OrderId = orderId}))
                {
                    return reader.Read<OrderDetail, Order, Product, OrderDetail>((detail, order, product) =>
                    {
                        detail.Order = order;
                        detail.Product = product;
                        return detail;
                    }, splitOn: "OrderId,ProductId").FirstOrDefault();
                }
            }
        }

        public void CreateOrder(OrderForInsert order)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Insert(order);
            }
        }

        public int Delete2017YearOrders()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                return con.Execute("DELETE FROM Northwind.Orders WHERE year(OrderDate) = '2017'");
            }
        }
    }
}
