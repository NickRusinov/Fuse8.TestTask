using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Репозиторий доступа к заказам
    /// </summary>
    public interface IOrderRepository : IReadOnlyCollection<Order>
    {
        /// <summary>
        /// Отсеивает заказы, дата которых строго меньше заданной 
        /// </summary>
        /// <param name="minDate">Минимальная дата</param>
        IOrderRepository WithMinDate(DateTime minDate);

        /// <summary>
        /// Отсеивает заказы, дата которых строго больше заданной
        /// </summary>
        /// <param name="maxDate">Максимальная дата</param>
        IOrderRepository WithMaxDate(DateTime maxDate);
    }
}
