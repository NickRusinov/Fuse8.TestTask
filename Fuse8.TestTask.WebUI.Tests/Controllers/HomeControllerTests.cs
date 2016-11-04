using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuse8.TestTask.WebUI.Controllers;
using Moq;
using Xunit;

namespace Fuse8.TestTask.WebUI.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexOrderRepositoryTest()
        {
            var orderRepository = MockOfOrderRepository();
            var sut = new HomeController(orderRepository, MockOfReportExporter(), MockOfReportSender());

            sut.Index(new DateTime(2010, 1, 1), new DateTime(2020, 1, 1), "from@email.com", "to@email.com");

            Mock.Get(orderRepository).Verify(or => or.WithMinDate(new DateTime(2010, 1, 1)));
            Mock.Get(orderRepository).Verify(or => or.WithMaxDate(new DateTime(2020, 1, 1)));
        }

        [Fact]
        public void IndexReportExporterTest()
        {
            var reportExporter = MockOfReportExporter();
            var sut = new HomeController(MockOfOrderRepository(), reportExporter, MockOfReportSender());

            sut.Index(new DateTime(2010, 1, 1), new DateTime(2020, 1, 1), "from@email.com", "to@email.com");

            Mock.Get(reportExporter).Verify(re => re.Export(It.IsAny<IReadOnlyCollection<Order>>()));
        }

        [Fact]
        public void IndexReportSenderTest()
        {
            var reportSender = MockOfReportSender();
            var sut = new HomeController(MockOfOrderRepository(), MockOfReportExporter(), reportSender);

            sut.Index(new DateTime(2010, 1, 1), new DateTime(2020, 1, 1), "from@email.com", "to@email.com");

            Mock.Get(reportSender).Verify(rs => rs.Send(It.IsAny<Stream>(), "from@email.com", "to@email.com"));
        }

        private static IOrderRepository MockOfOrderRepository()
        {
            return Mock.Of<IOrderRepository>(or =>
                or.WithMinDate(It.IsAny<DateTime>()) == or &&
                or.WithMaxDate(It.IsAny<DateTime>()) == or);
        }

        private static IReportExporter MockOfReportExporter()
        {
            return Mock.Of<IReportExporter>(re =>
                re.Export(It.IsAny<IReadOnlyCollection<Order>>()) == new MemoryStream());
        }

        private static IReportSender MockOfReportSender()
        {
            return Mock.Of<IReportSender>();
        }
    }
}
