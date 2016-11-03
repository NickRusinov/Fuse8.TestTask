using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class Fuse8Context : DbContext
    {
        public Fuse8Context(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            
        }

        /// <summary>
        /// Заказы, хранящиеся в базе данных
        /// </summary>
        public DbSet<Order> Orders { get; set; }
    }
}
