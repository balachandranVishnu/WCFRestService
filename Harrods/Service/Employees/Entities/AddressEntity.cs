using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Service DataContract for Address.
/// </summary>
namespace Harrods.Service.Employees.Entities
{
    [DataContract]
   
    public class AddressEntity
    {
        [DataMember]
        public int AddressID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }
        [DataMember]
        public string POBox { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]        
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
