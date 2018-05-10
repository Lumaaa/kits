using kits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kits.ViewModels
{
    public class Cart
    {
        private List<product> products = new List<product>();
        public decimal TotalPrice
        {
            // Linq syntax 
            get { return products.Sum(e => e.product_price ?? 0); }
        }

        public List<product> Products { get { return products; } }

        // Constructor
        public Cart() { }

        public void AddItem(product product, int quantity)
        {
            products.Add(product);
        }
        public void Clear()
        {
            products.Clear();
        }
    }
}