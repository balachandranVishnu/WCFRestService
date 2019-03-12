using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/// <summary>
///  Service DataContract for Employee.
/// </summary>
namespace Harrods.Service.Employees.Entities
{   [DataContract]
    public class EmployeeEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string Gender { get; set; } 
         
    }
}
