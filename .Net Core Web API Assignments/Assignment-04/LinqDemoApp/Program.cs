using System;
using System.Collections.Generic;
using System.Linq;

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
        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 1, Amount = 1200, OrderDate = DateTime.Now.AddDays(-10) },
            new Order { OrderId = 2, CustomerId = 1, Amount = 800,  OrderDate = DateTime.Now.AddDays(-40) },
            new Order { OrderId = 3, CustomerId = 2, Amount = 2000, OrderDate = DateTime.Now.AddDays(-5) },
            new Order { OrderId = 4, CustomerId = 2, Amount = 1500, OrderDate = DateTime.Now.AddDays(-20) },
            new Order { OrderId = 5, CustomerId = 3, Amount = 500,  OrderDate = DateTime.Now.AddDays(-2) }
        };

        //Calculate total order amount per customer using GroupBy
        var totalPerCustomer = orders
            .GroupBy(o => o.CustomerId)
            .Select(g => new
            {
                CustomerId = g.Key,
                TotalAmount = g.Sum(o => o.Amount)
            });
        
        Console.WriteLine("Total Order Amount Per Customer:");
        foreach (var item in totalPerCustomer)
        {
            Console.WriteLine($"Customer {item.CustomerId} - Total: {item.TotalAmount}");
        }   
    

        //Find top 3 customers by total spend
        var topCustomers = totalPerCustomer
            .OrderByDescending(c => c.TotalAmount)
            .Take(3);

        Console.WriteLine("\nTop 3 Customers By Total Spend:");
        foreach (var item in topCustomers)
        {
            Console.WriteLine($"Customer {item.CustomerId} - Total: {item.TotalAmount}");
        }


        //Fetch orders from last 30 days using Where
        var recentOrders = orders
            .Where(o => o.OrderDate >= DateTime.Now.AddDays(-30));

        Console.WriteLine("\nOrders From Last 30 Days:");
        foreach (var order in recentOrders)
        {
            Console.WriteLine($"OrderId: {order.OrderId}, Amount: {order.Amount}, Date: {order.OrderDate.ToShortDateString()}");
        }


        //Group orders by month
        var ordersByMonth = orders
            .GroupBy(o => o.OrderDate.Month);

        Console.WriteLine("\nOrders Grouped By Month:");
        foreach (var group in ordersByMonth)
        {
            Console.WriteLine($"Month: {group.Key}");
            foreach (var order in group)
            {
                Console.WriteLine($"  OrderId: {order.OrderId}, Amount: {order.Amount}");
            }
        }

        //Filter customers with average order value greater than 1000
        var highAvgCustomers = orders
            .GroupBy(o => o.CustomerId)
            .Where(g => g.Average(o => o.Amount) > 1000)
            .Select(g => g.Key);

        Console.WriteLine("\nCustomers With Average Order Value > 1000:");
        foreach (var customerId in highAvgCustomers)
        {
            Console.WriteLine($"Customer {customerId}");
        }
    }
}
