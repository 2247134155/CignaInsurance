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
    
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int DoctorID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Gender { get; set; }
        public System.DateTime DateofBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string Zip { get; set; }
        public string DoctorType { get; set; }
        public Nullable<int> HospitalID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}