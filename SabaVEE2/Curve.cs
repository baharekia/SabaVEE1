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
    
    public partial class Curve
    {
        public decimal CurveID { get; set; }
        public decimal MeterID { get; set; }
        public decimal ReadoutID { get; set; }
        public string CurveCode { get; set; }
        public string Point1Flow { get; set; }
        public string Point2Flow { get; set; }
        public string Point3Flow { get; set; }
        public string Point4Flow { get; set; }
        public string Point5Flow { get; set; }
        public string Point6Flow { get; set; }
        public string Point1Power { get; set; }
        public string Point2Power { get; set; }
        public string Point3Power { get; set; }
        public string Point4Power { get; set; }
        public string Point5Power { get; set; }
        public string Point6Power { get; set; }
        public string NoloadPower { get; set; }
        public string CalibrationFlow { get; set; }
        public string CalibrationPower { get; set; }
    
        public virtual Meter Meter { get; set; }
        public virtual OBISValueHeader OBISValueHeader { get; set; }
    }
}