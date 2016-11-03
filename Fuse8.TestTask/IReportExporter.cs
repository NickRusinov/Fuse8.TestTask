using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Экспорт заказов в виде отчета
    /// </summary>
    public interface IReportExporter
    {
        /// <summary>
        /// Экспортирует список заказов в отчет
        /// </summary>
        /// <param name="orders">Список заказов</param>
        /// <returns>Поток, представляющий отчет</returns>
        Stream Export(IReadOnlyCollection<Order> orders);
    }
}
