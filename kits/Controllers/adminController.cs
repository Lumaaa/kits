using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kits.Models;
using kits.ViewModels;

namespace kits.Controllers
{
    public class adminController : Controller
    {
        private kitsEntities db = new kitsEntities();

        // GET: orders
        public ActionResult Index()
        {
            var orders = db.orders.Include(o => o.state).Include(o => o.user);
            return View(orders.ToList());
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            List<product_order> orderItems = new List<product_order>();
            foreach (var orderItem in db.product_order.Include(product_order => product_order.product))
            {
                if (orderItem.orders_ID == order.order_ID) {
                    orderItems.Add(orderItem);
                }
            }

            return View(new OrderDetails
            {
                Order = order,
                OrderItems = orderItems
            });
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.state_ID = new SelectList(db.states, "state_ID", "name");
            ViewBag.users_ID = new SelectList(db.users, "users_ID", "user_email");
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_ID,users_ID,state_ID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.state_ID = new SelectList(db.states, "state_ID", "name", order.state_ID);
            ViewBag.users_ID = new SelectList(db.users, "users_ID", "user_email", order.users_ID);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.state_ID = new SelectList(db.states, "state_ID", "name", order.state_ID);
            ViewBag.users_ID = new SelectList(db.users, "users_ID", "user_email", order.users_ID);
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_ID,users_ID,state_ID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.state_ID = new SelectList(db.states, "state_ID", "name", order.state_ID);
            ViewBag.users_ID = new SelectList(db.users, "users_ID", "user_email", order.users_ID);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
