using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fuse8.TestTask.WebUI.Controllers;
using static System.Convert;

namespace Fuse8.TestTask.WebUI
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Home")
            {
                var fuse8Context = new Fuse8Context();

                var credentials = new NetworkCredential(
                    requestContext.HttpContext.Request.Form.Get("username"), 
                    requestContext.HttpContext.Request.Form.Get("password"));

                var smtpClient = new SmtpClient(
                    requestContext.HttpContext.Request.Form.Get("smtp"),
                    ToInt32(requestContext.HttpContext.Request.Form.Get("port")));
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                var mailSender = new MailSender(smtpClient);

                var orderRepository = new OrderRepository(fuse8Context.Orders.Include("OrderDetails.Product"));

                var reportExporter = new ReportExporter();

                var reportSender = new ReportSender(mailSender);

                return new HomeController(orderRepository, reportExporter, reportSender);
            }

            return base.CreateController(requestContext, controllerName);
        }

        public static void RegisterController(ControllerBuilder controllerBuilder)
        {
            controllerBuilder.SetControllerFactory(typeof(ControllerFactory));
        }
    }
}