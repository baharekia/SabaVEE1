//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SabaVEE2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Province
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Province()
        {
            this.Cities = new HashSet<City>();
        }
    
        public decimal ProvinceID { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public decimal CountryID { get; set; }
        public string ProvinceTelCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<City> Cities { get; set; }
        public virtual Country Country { get; set; }
    }
}
