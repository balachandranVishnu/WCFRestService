//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Harrods.Service.Employees.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int AddressID { get; set; }
        public int EmpID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string POBox { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
