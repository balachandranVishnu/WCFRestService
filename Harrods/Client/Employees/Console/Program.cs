using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Harrods.Proxy.Employees.ServiceProxy;
using Harrods.Service.Employees.Entities;
namespace Harrods.Client.Employees.ConsoleUI
{
    /// <summary>
    /// Sample program to connect WCF service using SOAP
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Create an Employee");
                EmployeeContractClient client = new EmployeeContractClient();
                EmployeeEntity employee = new EmployeeEntity();
                employee.FName = "Peter";
                employee.LName = "Parker";
                employee.Gender = "M";
                AddressEntity address = new AddressEntity();
                address.Line1 = "UST";
                address.Line2 = "TP Campus";
                address.Phone = "+44-4444-444-544";
                address.POBox = "1232";
                address.City = "TVM";
                address.Country = "IND";
                address.Email = "vishnu.balachandran@ust-global.com";                
                client.CreateEmployeeAsync(employee, address).GetAwaiter().GetResult();

            }
            catch (FaultException<ExceptionFaultContract> faultException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }


        }

        private static async Task CreateNewEmployee(EmployeeEntity employee, AddressEntity address, EmployeeContractClient client)
        {
            try
            {
                Task<bool> data = client.CreateEmployeeAsync(employee, address);
                bool Sucess = await data;
                if (data.IsFaulted)
                    throw data.Exception;
            }
            catch (FaultException<ExceptionFaultContract> faultException)
            {
                throw;
            }
        }
    }
}
