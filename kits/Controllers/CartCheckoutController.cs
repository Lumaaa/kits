using kits.Models;
using kits.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kits.Controllers
{
    public class CartCheckoutController : Controller
    {
        private kitsEntities db = new kitsEntities();

        public ActionResult Index(Cart cart, user user)
        {
            ViewBag.zipcode = new SelectList(db.zipcodes, "zipcode1", "city");
            return View(new CartCheckoutIndexViewModel
            {
                Cart = cart,
                User = user
            });
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "users_ID,user_email,user_pasword,user_address,user_firstname,user_lastname,user_phone,zipcode")] user user)
        {
            Cart cart = (Cart)Session["Cart"];
            if (ModelState.IsValid && cart != null)
            {
                db.users.Add(user);
                db.SaveChanges();

                order newOrder = new order();
                newOrder.state_ID = 1;
                newOrder.users_ID = user.users_ID;
                db.orders.Add(newOrder);
                db.SaveChanges();
                
                foreach (var product in cart.Products) {
                    product_order orderItem = new product_order();
                    orderItem.orders_ID = newOrder.order_ID;
                    orderItem.product_ID = product.product_ID;
                    db.product_order.Add(orderItem);
                }

                cart.Clear();
                return RedirectToAction("Index");
            }
          
            ViewBag.zipcode = new SelectList(db.zipcodes, "zipcode1", "city", user.zipcode);
            return View();
        }
    }
}