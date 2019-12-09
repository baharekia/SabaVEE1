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
    
    public partial class OBISS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OBISS()
        {
            this.OBISToReports = new HashSet<OBISToReport>();
            this.OBISValueDetails = new HashSet<OBISValueDetail>();
        }
    
        public decimal OBISID { get; set; }
        public string Obis { get; set; }
        public string ObisCode { get; set; }
        public string ObisFarsiDesc { get; set; }
        public string ObisLatinDesc { get; set; }
        public string ObisArabicDesc { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsVisable { get; set; }
        public Nullable<decimal> DeviceTypeID { get; set; }
        public Nullable<decimal> OBISUnitID { get; set; }
        public Nullable<decimal> ObisTypeID { get; set; }
        public string Format { get; set; }
        public Nullable<int> ClassID { get; set; }
        public string CardFormatType { get; set; }
        public string HHuFormatType { get; set; }
        public Nullable<int> UnitConvertType { get; set; }
        public Nullable<decimal> UnitIDForshow { get; set; }
        public string FixedOBISCode { get; set; }
        public string regulationRuleDesc { get; set; }
        public Nullable<int> PriorityForShow { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBISToReport> OBISToReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBISValueDetail> OBISValueDetails { get; set; }
    }
}