using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Товар
    /// </summary>
    [Table("Product")]
    public class Product
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        // ... Остальные аттрибуты таблицы не используются

        /// <summary>
        /// Связанные с товаром позиции заказа
        /// </summary>
        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}
