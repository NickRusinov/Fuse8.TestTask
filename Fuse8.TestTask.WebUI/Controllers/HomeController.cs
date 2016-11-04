using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fuse8.TestTask.WebUI.Models.Home;

namespace Fuse8.TestTask.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository orderRepository;

        private readonly IReportExporter reportExporter;

        private readonly IReportSender reportSender;

        public HomeController(IOrderRepository orderRepository, IReportExporter reportExporter, IReportSender reportSender)
        {
            this.orderRepository = orderRepository;
            this.reportExporter = reportExporter;
            this.reportSender = reportSender;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel model)
        {
            var orders = orderRepository.WithMinDate(model.MinDate ?? DateTime.MinValue).WithMaxDate(model.MaxDate ?? DateTime.MaxValue);
            var report = reportExporter.Export(orders);
            reportSender.Send(report, model.From, model.To);

            ViewBag.Success = true;

            return View(model);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var model = new IndexViewModel();

            TryUpdateModel(model);
            ViewBag.Error = filterContext.Exception;

            filterContext.ExceptionHandled = true;
            filterContext.Result = View("~/Views/Home/Index.cshtml", model);
        }
    }
}