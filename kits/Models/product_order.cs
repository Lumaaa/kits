//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kits.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product_order
    {
        public int product_order_ID { get; set; }
        public Nullable<int> orders_ID { get; set; }
        public Nullable<int> product_ID { get; set; }
        public string product_size { get; set; }
    
        public virtual order order { get; set; }
        public virtual product product { get; set; }
    }
}
