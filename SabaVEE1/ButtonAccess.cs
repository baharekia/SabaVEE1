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
    
    public partial class ButtonAccess
    {
        public decimal ButtonID { get; set; }
        public decimal UserID { get; set; }
        public bool CanShow { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanInsert { get; set; }
        public Nullable<bool> CanImportFromFile { get; set; }
    
        public virtual Button Button { get; set; }
        public virtual User User { get; set; }
    }
}