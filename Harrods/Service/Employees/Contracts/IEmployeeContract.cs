using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using Harrods.Service.Employees.Entities;
using System.Data;
/// <summary>
/// Service Contracts class. Handles REST and SOAP service contracts for
/// handling employee and address crud operations.
/// The logs were tracked in a svc log file which is available in the Host Project.
/// 
/// </summary>
namespace Harrods.Service.Employees.Contracts
{
    [ServiceContract]
    public interface IEmployeeContract
    {
         
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "POST", UriTemplate = "CreateEmployee" ,BodyStyle =WebMessageBodyStyle.Wrapped, 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)] 
        Task<bool>  CreateEmployeeAsync(EmployeeEntity Employee,AddressEntity address);

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateEmployee", //BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> UpdateEmployeeAsync(EmployeeEntity Employee);

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteEmployee",  BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> DeleteEmployeeAsync(EmployeeEntity Employee);

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "GET", UriTemplate = "GetEmployee/?EmployeeID={employeeID}", BodyStyle = WebMessageBodyStyle.Wrapped, 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<EmployeeEntity> GetEmployeeAsync(int EmployeeID);

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "GET", UriTemplate = "GetEmployees" , BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync(); 

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateAddress", BodyStyle = WebMessageBodyStyle.Wrapped, 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> UpdateAddressAsync(AddressEntity Address);

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteAddress", BodyStyle = WebMessageBodyStyle.Wrapped, 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> DeleteAddressAsync(AddressEntity Address);

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        [WebInvoke(Method = "GET", UriTemplate = "GetAddress/?AddressID={addressID}", BodyStyle = WebMessageBodyStyle.Wrapped, 
            ResponseFormat = WebMessageFormat.Json)]
        Task<AddressEntity> GetAddressAsync(int AddressID);
         
    }
}
