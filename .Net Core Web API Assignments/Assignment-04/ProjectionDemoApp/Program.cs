using System;
using System.Collections.Generic;
using System.Linq;

class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}

class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime OrderDate { get; set; }
}

class Program
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                Name = "Meet1",
                Orders = new List<Order>
                {
                    new Order { OrderId = 1, CustomerId = 1, Amount = 1200, OrderDate = DateTime.Now.AddDays(-5) },
                    new Order { OrderId = 2, CustomerId = 1, Amount = 800,  OrderDate = DateTime.Now.AddDays(-15) }
                }
            },
            new Customer
            {
                CustomerId = 2,
                Name = "Meet2",
                Orders = new List<Order>
                {
                    new Order { OrderId = 3, CustomerId = 2, Amount = 2000, OrderDate = DateTime.Now.AddDays(-2) }
                }
            }
        };

        //Use Select to project customer summaries
        var customerSummary = customers
            .Select(c => new
            {
                c.CustomerId,
                c.Name,
                OrderCount = c.Orders.Count,
                TotalAmount = c.Orders.Sum(o => o.Amount)
            });

        Console.WriteLine("Customer Summary:");
        foreach (var item in customerSummary)
        {
            Console.WriteLine(
                $"CustomerId: {item.CustomerId}, Name: {item.Name}, Orders: {item.OrderCount}, Total: {item.TotalAmount}"
            );
        }

        //Use SelectMany to flatten all orders across customers
        var allOrders = customers
            .SelectMany(c => c.Orders);

        Console.WriteLine("\nAll Orders (Flattened):");
        foreach (var order in allOrders)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, CustomerId: {order.CustomerId}, Amount: {order.Amount}, Date: {order.OrderDate.ToShortDateString()}"
            );
        }

        //Calculate total order count and amount
        int totalOrders = allOrders.Count();
        decimal totalAmount = allOrders.Sum(o => o.Amount);

        Console.WriteLine("\nTotal Orders: " + totalOrders);
        Console.WriteLine("Total Amount: " + totalAmount);
    }
}
