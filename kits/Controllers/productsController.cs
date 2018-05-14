using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kits.Models;

namespace kits.Controllers
{
    public class productsController : Controller
    {
        private kitsEntities db = new kitsEntities();

        // GET: products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.brand).Include(p => p.category);
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> sizes = new List<SelectListItem>();
            if (product.XS > 0) { sizes.Add(new SelectListItem { Text = "XS", Value = "XS" }); };
            if (product.S > 0) { sizes.Add(new SelectListItem { Text = "S", Value = "S" }); };
            if (product.M > 0) { sizes.Add(new SelectListItem { Text = "M", Value = "M" }); };
            if (product.L > 0) { sizes.Add(new SelectListItem { Text = "L", Value = "L" }); };
            if (product.XL > 0) { sizes.Add(new SelectListItem { Text = "XL", Value = "XL" }); };
            ViewBag.sizes = sizes;

            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.brand_ID = new SelectList(db.brands, "brand_ID", "name");
            ViewBag.category_ID = new SelectList(db.categories, "category_ID", "name");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_ID,product_name,brand_ID,category_ID,product_description,size_ID,product_price")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_ID = new SelectList(db.brands, "brand_ID", "name", product.brand_ID);
            ViewBag.category_ID = new SelectList(db.categories, "category_ID", "name", product.category_ID);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_ID = new SelectList(db.brands, "brand_ID", "name", product.brand_ID);
            ViewBag.category_ID = new SelectList(db.categories, "category_ID", "name", product.category_ID);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_ID,product_name,brand_ID,category_ID,product_description,size_ID,product_price")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_ID = new SelectList(db.brands, "brand_ID", "name", product.brand_ID);
            ViewBag.category_ID = new SelectList(db.categories, "category_ID", "name", product.category_ID);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
