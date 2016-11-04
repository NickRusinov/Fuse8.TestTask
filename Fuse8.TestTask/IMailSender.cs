using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Интерфейс для тестирования отправки письма по электронной почте
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// Отправляет письмо по электронной почте
        /// </summary>
        /// <param name="message">Сообщение</param>
        void Send(MailMessage message);
    }
}
