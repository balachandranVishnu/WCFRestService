using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Service DataContract for handling exceptions.
/// </summary>
namespace Harrods.Service.Employees.Entities
{
    [DataContract]
    public class ExceptionFaultContract
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
        [DataMember]
        public string BaseException { get; set; }
    }
}
