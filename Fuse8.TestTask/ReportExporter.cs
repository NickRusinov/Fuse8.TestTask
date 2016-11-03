using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Fuse8.TestTask
{
    /// <summary>
    /// Экспорт заказов в виде отчета в формате Excel
    /// </summary>
    public class ReportExporter : IReportExporter
    {
        /// <summary>
        /// Экспортирует список заказов в отчет
        /// </summary>
        /// <param name="orders">Список заказов</param>
        /// <returns>Поток, представляющий отчет</returns>
        public Stream Export(IReadOnlyCollection<Order> orders)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Отчет");
                var row = 2;

                workSheet.InsertRow(1, 1);
                workSheet.Cells[1, 1].Value = "Номер заказа";
                workSheet.Cells[1, 2].Value = "Дата заказа";
                workSheet.Cells[1, 3].Value = "Артикул товара";
                workSheet.Cells[1, 4].Value = "Наименование товара";
                workSheet.Cells[1, 5].Value = "Количество";
                workSheet.Cells[1, 6].Value = "Цена за единицу товара";
                workSheet.Cells[1, 7].Value = "Цена итоговая";

                foreach (var orderDetail in orders.SelectMany(o => o.OrderDetails))
                {
                    workSheet.InsertRow(row, 1);
                    workSheet.Cells[row, 1].Value = orderDetail.Order.Id;
                    workSheet.Cells[row, 2].Value = orderDetail.Order.OrderDate;
                    workSheet.Cells[row, 3].Value = orderDetail.Product.Id;
                    workSheet.Cells[row, 4].Value = orderDetail.Product.Name;
                    workSheet.Cells[row, 5].Value = orderDetail.Quantity;
                    workSheet.Cells[row, 6].Value = orderDetail.UnitPrice;
                    workSheet.Cells[row, 7].FormulaR1C1 = "RC[-2]*RC[-1]";

                    row++;
                }

                package.Save();
            }

            return stream;
        }
    }
}
