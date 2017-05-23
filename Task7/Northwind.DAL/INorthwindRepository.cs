using System.Collections.Generic;
using Northwind.DAL.Entities;

namespace Northwind.DAL
{
    public interface INorthwindRepository
    {
        IEnumerable<Order> GetOrders();

        IEnumerable<OrderDetail> GetOrdersDetails();

        OrderDetail GetOrderDetails(int orderId);

        void CreateOrder(OrderForInsert order);

        int Delete2017YearOrders();
    }
}