using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Xunit;

namespace Fuse8.TestTask.Tests
{
    public class ReportExporterTests : IClassFixture<Fuse8ContextFixture>
    {
        private readonly Fuse8ContextFixture contextFixture;

        public ReportExporterTests(Fuse8ContextFixture contextFixture)
        {
            this.contextFixture = contextFixture;
        }

        [Fact]
        public void ExportTest()
        {
            var sut = new ReportExporter();

            var stream = sut.Export(contextFixture.Context.Orders.ToList());
            var package = new ExcelPackage(stream);

            AssertRow(package.Workbook.Worksheets[1], 2, 1, new DateTime(2010, 1, 2), 1, "ProductA", 1, 10.00m);
            AssertRow(package.Workbook.Worksheets[1], 3, 2, new DateTime(2011, 2, 3), 1, "ProductA", 2, 15.00m);
            AssertRow(package.Workbook.Worksheets[1], 4, 2, new DateTime(2011, 2, 3), 2, "ProductB", 3, 20.00m);
            AssertRow(package.Workbook.Worksheets[1], 5, 3, new DateTime(2012, 3, 4), 2, "ProductB", 4, 25.00m);
            AssertRow(package.Workbook.Worksheets[1], 6, 3, new DateTime(2012, 3, 4), 3, "ProductC", 5, 30.00m);
        }

        private static void AssertRow(ExcelWorksheet worksheet, int row, int orderId, DateTime orderDate, int productId, string productName, int quantity, decimal unitPrice)
        {
            Assert.Equal(orderId, worksheet.GetValue<int>(row, 1));
            Assert.Equal(orderDate, worksheet.GetValue<DateTime>(row, 2));
            Assert.Equal(productId, worksheet.GetValue<int>(row, 3));
            Assert.Equal(productName, worksheet.GetValue<string>(row, 4));
            Assert.Equal(quantity, worksheet.GetValue<int>(row, 5));
            Assert.Equal(unitPrice, worksheet.GetValue<decimal>(row, 6));
        }
    }
}
