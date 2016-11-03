using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;

namespace Fuse8.TestTask.Tests
{
    public class Fuse8ContextFixture
    {
        public Fuse8ContextFixture()
        {
            var orders = new List<Order>
            {
                new Order { Id = 1, OrderDate = new DateTime(2010, 1, 2) },
                new Order { Id = 2, OrderDate = new DateTime(2011, 2, 3) },
                new Order { Id = 3, OrderDate = new DateTime(2012, 3, 4) },
                new Order { Id = 4, OrderDate = new DateTime(2013, 4, 5) },
                new Order { Id = 5, OrderDate = new DateTime(2014, 5, 6) },
            };

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "ProductA" },
                new Product { Id = 2, Name = "ProductB" },
                new Product { Id = 3, Name = "ProductC" },
                new Product { Id = 4, Name = "ProductD" },
                new Product { Id = 5, Name = "ProductE" },
            };

            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { Id = 1, Product = products[0], Order = orders[0], Quantity = 1, UnitPrice = 10.00m },
                new OrderDetail { Id = 2, Product = products[0], Order = orders[1], Quantity = 2, UnitPrice = 15.00m },
                new OrderDetail { Id = 3, Product = products[1], Order = orders[1], Quantity = 3, UnitPrice = 20.00m },
                new OrderDetail { Id = 4, Product = products[1], Order = orders[2], Quantity = 4, UnitPrice = 25.00m },
                new OrderDetail { Id = 5, Product = products[2], Order = orders[2], Quantity = 5, UnitPrice = 30.00m },
            };

            orders.ForEach(o => o.OrderDetails = orderDetails.Where(od => od.Order == o).ToList());
            products.ForEach(p => p.OrderDetails = orderDetails.Where(od => od.Product == p).ToList());

            Context = new Fuse8Context(DbConnectionFactory.CreateTransient(), true);
            Context.Orders.AddRange(orders);
            Context.SaveChanges();
        }

        public Fuse8Context Context { get; }
    }
}
