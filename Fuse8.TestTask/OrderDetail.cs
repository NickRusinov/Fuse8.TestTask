using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Позиция заказа
    /// </summary>
    [Table("OrderDetail")]
    public class OrderDetail
    {
        /// <summary>
        /// Идентификатор позиции заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Связанный заказ
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Связанный товар
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Цена за единицу товара
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Quantity { get; set; }
    }
}
