using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Отправка отчетов по электронной почте
    /// </summary>
    public interface IReportSender
    {
        /// <summary>
        /// Отправляет отчет по электронной посте с указанием адресов отправителя и получателя
        /// </summary>
        /// <param name="report">Отправляемый отчет</param>
        /// <param name="from">Электронный адрес отправителя</param>
        /// <param name="to">Электронный адрес получателя</param>
        void Send(Stream report, string from, string to);
    }
}
