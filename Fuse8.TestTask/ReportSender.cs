using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Отправка отчетов по электронной почте
    /// </summary>
    public class ReportSender : IReportSender
    {
        private static readonly string messageSubject = 
            "Тестовое задание";

        private static readonly string messageBody =
            "Тестовое задание" + NewLine + 
            "by Русинов Николай (gultuy00@gmail.com)";
        
        private readonly IMailSender mailSender;

        public ReportSender(IMailSender mailSender)
        {
            this.mailSender = mailSender;
        }

        /// <summary>
        /// Отправляет отчет по электронной посте с указанием адресов отправителя и получателя
        /// </summary>
        /// <param name="report">Отправляемый отчет</param>
        /// <param name="from">Электронный адрес отправителя</param>
        /// <param name="to">Электронный адрес получателя</param>
        public void Send(Stream report, string from, string to)
        {
            var message = new MailMessage(from, to, messageSubject, messageBody);
            message.Attachments.Add(new Attachment(report, "Отчет"));

            mailSender.Send(message);
        }
    }
}
