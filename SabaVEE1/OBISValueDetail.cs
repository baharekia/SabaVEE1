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
    
    public partial class OBISValueDetail
    {
        public decimal ObisValueID { get; set; }
        public decimal OBISValueHeaderID { get; set; }
        public decimal OBISID { get; set; }
        public string Value { get; set; }
        public string VEEValue { get; set; }
        public bool Valid { get; set; }
        public Nullable<decimal> ReadValuUnitID { get; set; }
    
        public virtual OBISS OBISS { get; set; }
        public virtual OBISUnit OBISUnit { get; set; }
        public virtual OBISValueHeader OBISValueHeader { get; set; }
    }
}
