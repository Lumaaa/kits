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
        private IEnumerable<product> products = new List<product>();
        private List<SelectListItem> categories = new List<SelectListItem>();

        // GET: products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.brand).Include(p => p.category);
            foreach (var category in db.categories)
            {
                categories.Add(new SelectListItem
                {
                    Text = category.name,
                    Value = category.category_ID.ToString()
                });
            }
            products = db.products;

            ViewBag.CategoryId = categories;
            ViewBag.Products = products;

            return View();
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

        [HttpPost]
        public ActionResult Index(int? CategoryId)
        {
            foreach (var category in db.categories)
            {
                categories.Add(new SelectListItem
                {
                    Text = category.name,
                    Value = category.category_ID.ToString()
                });
            }

            if (CategoryId == null) {
                products = db.products;
            } else {
                products = db.products.Where(r => r.category_ID == CategoryId);
            }

            ViewBag.CategoryId = categories;
            ViewBag.Products = products;

            return View();
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
