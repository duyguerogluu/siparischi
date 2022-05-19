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
    
    public partial class Business
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Business()
        {
            this.BusinessRatings = new HashSet<BusinessRating>();
            this.Campaigns = new HashSet<Campaign>();
            this.Categories = new HashSet<Category>();
        }
    
        public int id { get; set; }
        public string business_name { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string neighbourhood { get; set; }
        public Nullable<bool> situation { get; set; }
        public Nullable<System.DateTime> starting_date { get; set; }
        public Nullable<System.DateTime> ending_date { get; set; }
        public string image_name { get; set; }
        public string location { get; set; }
        public Nullable<int> business_type_id { get; set; }
        public string business_key { get; set; }
    
        public virtual BusinessType BusinessType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessRating> BusinessRatings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campaign> Campaigns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
