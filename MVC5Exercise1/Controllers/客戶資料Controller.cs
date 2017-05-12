using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Exercise1.Models;

namespace MVC5Exercise1.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: 客戶資料
        public ActionResult Index()
        {
            // 一次查出全部資料丟給 View 去呈現
            //return View(db.客戶資料.ToList());

            // 註解掉：因一開始不需要撈出所有客戶資料，應該是空白頁面，輸入篩選條件查詢才有結果
            // 使用 AsQueryable()，延遲查詢(在執行 View 的 Foreach 中才會真的去資料庫查詢，效能較佳)
            //var result = db.客戶資料.Where(c => c.是否已刪除 == false).AsQueryable();            
            //return View(result);

            // 註記目前是沒有資料
            ViewBag.HasData = false; 

            return View();
        }

        [HttpPost]
        public ActionResult Search(string 客戶名稱)
        {
            IEnumerable<客戶資料> result = null;

            // 註記目前是有在做查詢資料
            ViewBag.IsSearching = true;

            // 如果未輸入，打回重新輸入
            if (string.IsNullOrEmpty(客戶名稱))
            {
                ModelState.AddModelError("", "請輸入查詢條件：客戶名稱");
            }
            else // 有輸入條件，執行查詢作業
            {
                result = db.客戶資料
                    .Where(c => c.是否已刪除 == false 
                           && 
                           c.客戶名稱.ToUpper().Contains(客戶名稱.Trim().ToUpper()))
                    .ToList();

                if (result.Count() > 0)
                {
                    // 註記目前是有資料
                    ViewBag.HasData = true;
                }
                else
                {
                    // 註記目前是沒有資料
                    ViewBag.HasData = false;
                }
            }

            //  指定回傳到 Index 查詢頁面，以顯示結果
            return View("Index",result);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        //public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,是否已刪除")] 客戶資料 客戶資料)
        public ActionResult Create(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        public ActionResult Edit(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);

            // 刪除資料功能不能真的刪除資料庫中的資料，必須修改資料庫，註記「是否已刪除」欄位為 true
            //db.客戶資料.Remove(客戶資料);
            客戶資料.是否已刪除 = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
