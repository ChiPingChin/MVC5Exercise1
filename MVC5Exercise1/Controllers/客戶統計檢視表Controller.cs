using MVC5Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Exercise1.Controllers
{
    public class 客戶統計檢視表Controller : Controller
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: 客戶統計檢視表
        public ActionResult Index()
        {
            var result = db.客戶統計檢視表.AsQueryable();

            return View(result);
        }
    }
}