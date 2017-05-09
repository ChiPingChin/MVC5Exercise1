using MVC5Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Exercise1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //using (CustomerEntities db = new CustomerEntities())
            //{
            //    //var data = db.客戶資料.AsQueryable();
            //    var data = db.客戶資料.ToList();

            //    return View(data);
            //}

            return View();
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
    }
}