using System;
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
                Console.WriteLine($@"ID {client.CustomerID} SUM {client.Orders.Sum(o => o.Total)}");
        }
    }
}
