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
            Context = new Fuse8Context(DbConnectionFactory.CreateTransient(), true);

            Context.Orders.Add(new Order { Id = 1, OrderDate = new DateTime(2010, 1, 2) });
            Context.Orders.Add(new Order { Id = 2, OrderDate = new DateTime(2011, 2, 3) });
            Context.Orders.Add(new Order { Id = 3, OrderDate = new DateTime(2012, 3, 4) });
            Context.Orders.Add(new Order { Id = 4, OrderDate = new DateTime(2013, 4, 5) });
            Context.Orders.Add(new Order { Id = 5, OrderDate = new DateTime(2014, 5, 6) });

            Context.SaveChanges();
        }

        public Fuse8Context Context { get; }
    }
}
