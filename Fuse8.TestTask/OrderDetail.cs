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
        /// Идентификатор связанного заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Идентификатор связанного товара
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Связанный заказ
        /// </summary>
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        /// <summary>
        /// Связанный товар
        /// </summary>
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        /// <summary>
        /// Цена за единицу товара
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public short Quantity { get; set; }
    }
}
