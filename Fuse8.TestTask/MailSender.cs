using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Реализация интерфейса для тестирования отправки письма по электронной почте
    /// </summary>
    public class MailSender : IMailSender
    {
        private readonly SmtpClient smtpClient;

        public MailSender(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }

        /// <summary>
        /// Отправляет письмо по электронной почте
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Send(MailMessage message)
        {
            smtpClient.Send(message);
        }
    }
}
