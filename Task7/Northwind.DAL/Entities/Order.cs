using System;

namespace Northwind.DAL.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public Customer Customer { get; set; }

        public int? EmployeeID { get; set; }

        public Employee Employee { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public OrderStatus OrderStatus =>
            OrderDate == null
                ? OrderStatus.New
                : (ShippedDate == null
                    ? OrderStatus.InProgress
                    : OrderStatus.Complete);
    }
}
