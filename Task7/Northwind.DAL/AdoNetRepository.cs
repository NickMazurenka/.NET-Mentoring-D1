using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Northwind.DAL.Entities;

namespace Northwind.DAL
{
    public class AdoNetRepository : INorthwindRepository
    {
        private readonly string _connectionString;

        public AdoNetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private T GetNullable<T>(object obj)
        {
            return (obj == DBNull.Value ? default(T) : (T)obj);
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                SqlDataReader sqlDataReader = null;
                var sqlCommand = new SqlCommand(@"SELECT * FROM Northwind.Orders", sqlConnection);

                try
                {
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var order = new Order
                        {
                            OrderID = GetNullable<int>(sqlDataReader["OrderId"]),
                            OrderDate = GetNullable<DateTime?>(sqlDataReader["OrderDate"]),
                            ShippedDate = GetNullable<DateTime?>(sqlDataReader["ShippedDate"])
                        };
                        orders.Add(order);
                    }
                }
                finally
                {
                    sqlDataReader?.Close();
                }

                return orders;
            }
        }

        public IEnumerable<OrderDetail> GetOrdersDetails()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(OrderForInsert order)
        {
            throw new NotImplementedException();
        }

        public int Delete2017YearOrders()
        {
            throw new NotImplementedException();
        }
    }
}
