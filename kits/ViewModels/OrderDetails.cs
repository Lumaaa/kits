using kits.Models;
using System.Collections.Generic;

namespace kits.ViewModels
{
    public class OrderDetails
    {
        public user User { get; set; }
        public order Order { get; set; }
        public List<product_order> OrderItems = new List<product_order>();
    }
}