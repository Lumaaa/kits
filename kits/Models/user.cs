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
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.orders = new HashSet<order>();
        }
    
        public int users_ID { get; set; }
        public string user_email { get; set; }
        public string user_pasword { get; set; }
        public string user_address { get; set; }
        public string user_firstname { get; set; }
        public string user_lastname { get; set; }
        public Nullable<int> user_phone { get; set; }
        public Nullable<int> zipcode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
        public virtual zipcode zipcode1 { get; set; }
    }
}
