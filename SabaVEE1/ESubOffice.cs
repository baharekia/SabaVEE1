//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SabaVEE1
{
    using System;
    using System.Collections.Generic;
    
    public partial class ESubOffice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESubOffice()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public decimal ESubOfficeID { get; set; }
        public string ESubOfficeCode { get; set; }
        public string ESubOfficeDesc { get; set; }
        public Nullable<decimal> OfficeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
