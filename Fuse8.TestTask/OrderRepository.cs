using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Репозиторий доступа к заказам
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly IQueryable<Order> orders;

        public OrderRepository(IQueryable<Order> orders)
        {
            this.orders = orders;
        }

        /// <summary>
        /// Отсеивает заказы, дата которых строго меньше заданной 
        /// </summary>
        /// <param name="minDate">Минимальная дата</param>
        public IOrderRepository WithMinDate(DateTime minDate)
        {
            return new OrderRepository(
                orders.Where(o => o.OrderDate >= minDate));
        }

        /// <summary>
        /// Отсеивает заказы, дата которых строго больше заданной
        /// </summary>
        /// <param name="maxDate">Максимальная дата</param>
        public IOrderRepository WithMaxDate(DateTime maxDate)
        {
            return new OrderRepository(
                orders.Where(o => o.OrderDate <= maxDate));
        }

        public int Count => orders.Count();

        public IEnumerator<Order> GetEnumerator() => orders.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
