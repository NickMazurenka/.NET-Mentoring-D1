using System.Security.AccessControl;

namespace Northwind.DAL.Entities
{
    public class OrderDetail
    {
        public int OrderID { get; set; }

        public Order Order { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public double Discount { get; set; }

    }
}
