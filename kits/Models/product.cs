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
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.product_order = new HashSet<product_order>();
        }
    
        public int product_ID { get; set; }
        public string product_name { get; set; }
        public Nullable<int> brand_ID { get; set; }
        public Nullable<int> category_ID { get; set; }
        public string product_description { get; set; }
        public Nullable<int> size_ID { get; set; }
        public Nullable<decimal> product_price { get; set; }
    
        public virtual brand brand { get; set; }
        public virtual category category { get; set; }
        public virtual size size { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product_order> product_order { get; set; }
    }
}
