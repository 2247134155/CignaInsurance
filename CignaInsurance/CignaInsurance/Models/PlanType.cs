//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CignaInsurance.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlanType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanType()
        {
            this.Plans = new HashSet<Plan>();
        }
    
        public int PlanTypeID { get; set; }
        public string PlanTypeName { get; set; }
        public string PlanTypeDescription { get; set; }
        public string PlanDetails { get; set; }
        public int PlanTypeFee { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
