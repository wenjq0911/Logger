using Logger.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logger.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save() {
            return Content("ok");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult error()
        {
            string x = null;
            var a = x.Length;
            return Content("测试");
        }

        public ActionResult test()
        {
            return Content("测试");
        }
        [HttpPost]
        [LoggerOperation(Remark ="添加信息",Type = OptTypes.Insert)]
        public ActionResult save() {
            return Content("OK");
        }
    }
}