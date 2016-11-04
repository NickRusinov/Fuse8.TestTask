using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Fuse8.TestTask.Tests
{
    public class ReportSenderTests
    {
        [Fact]
        public void SendTest()
        {
            var mailSender = Mock.Of<IMailSender>();
            var stream = new MemoryStream();
            var sut = new ReportSender(mailSender);

            sut.Send(stream, "from@email.com", "to@email.com");

            Mock.Get(mailSender).Verify(ms => ms.Send(It.Is<MailMessage>(mm => mm.From.Address == "from@email.com")));
            Mock.Get(mailSender).Verify(ms => ms.Send(It.Is<MailMessage>(mm => mm.To.Any(ma => ma.Address == "to@email.com"))));
            Mock.Get(mailSender).Verify(ms => ms.Send(It.Is<MailMessage>(mm => mm.Attachments.Any(a => a.ContentStream == stream))));
        }
    }
}
