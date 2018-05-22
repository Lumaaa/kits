using kits.Models;
using System.Collections.Generic;

namespace kits.ViewModels
{
    public class OrderDetails
    {
        public order Order { get; set; }
        public List<product_order> OrderItems = new List<product_order>();
    }
}