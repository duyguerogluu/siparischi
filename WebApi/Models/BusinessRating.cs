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
    
    public partial class BusinessRating
    {
        public int id { get; set; }
        public Nullable<int> point_value { get; set; }
        public Nullable<int> business_id { get; set; }
        public Nullable<int> user_id { get; set; }
    
        public virtual Business Business { get; set; }
        public virtual User User { get; set; }
    }
}