using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuse8.TestTask.WebUI.Models.Home
{
    public class IndexViewModel
    {
        public DateTime? MinDate { get; set; }

        public DateTime? MaxDate { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Smtp { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }
    }
}