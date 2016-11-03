using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Заказ
    /// </summary>
    [Table("Order")]
    public class Order
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime OrderDate { get; set; }
        
        // ... Остальные аттрибуты таблицы не используются

        /// <summary>
        /// Связанные позиции заказа
        /// </summary>
        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}
