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
    
    public partial class Window
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Window()
        {
            this.OldOBISses = new HashSet<OldOBISs>();
        }
    
        public int WindowID { get; set; }
        public string windowLatinName { get; set; }
        public string windowFarsiName { get; set; }
        public string windowArabicName { get; set; }
        public Nullable<bool> IsVisable { get; set; }
        public Nullable<decimal> OBIStypeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OldOBISs> OldOBISses { get; set; }
    }
}
