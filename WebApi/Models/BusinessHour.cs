//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusinessHour
    {
        public int id { get; set; }
        public Nullable<System.TimeSpan> opening_hour { get; set; }
        public Nullable<System.TimeSpan> closing_hour { get; set; }
        public Nullable<int> business_id { get; set; }
        public Nullable<int> business_work_type_id { get; set; }
    
        public virtual BusinessWorkType BusinessWorkType { get; set; }
    }
}
