using Microsoft.VisualStudio.TestTools.UnitTesting;
using Harrods.Service.Employees.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harrods.Service.Employees.Entities;
/// <summary>
/// Visual Studio test project for invoking SOAP tests.
/// </summary>
namespace Harrods.Service.Employees.Implementation.Tests
{
    [TestClass()]
    public class EmployeeImplUsingProxyTests
    {

        [TestMethod]
        public void CreateProxyClient()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            Assert.IsInstanceOfType(client, typeof(EmployeeContractClient));
        }

        //[TestMethod()]         
        public async Task CreateNewEmployee()
        {

            EmployeeContractClient client = new EmployeeContractClient();
            EmployeeEntity employee = new EmployeeEntity();
            employee.FName = "Vishnu";
            employee.LName = "KB";
            employee.Gender = "M";

            AddressEntity address = new AddressEntity();
            address.Line1 = "UST";
            address.Line2 = "TP Campus";
            address.Phone = "23-322-327272552";
            address.POBox = "1232";
            address.City = "TVM";
            address.Country = "IND";
            address.Email = "vis@kb.com";

            Task<bool> Result = client.CreateEmployeeAsync(employee, address);
            bool Success = await Result;

            Assert.Equals(Success, true);
        }



        public async Task CreateNewEmployeeWithInvalidData()
        {

            EmployeeContractClient client = new EmployeeContractClient();
            EmployeeEntity employee = new EmployeeEntity();
            employee.FName = "Vishnu";
            employee.LName = "KB";
            employee.Gender = "M";

            AddressEntity address = new AddressEntity();
            address.Line1 = "UST";
            address.Line2 = "TP Campus";
            address.Phone = "+44-4444-444-444";
            address.POBox = "1232";
            address.City = "TVM";
            address.Country = "IND";
            address.Email = "vis-hn@kb.com";

            Task<bool> Result = client.CreateEmployeeAsync(employee, address);
            bool Success = await Result;

            Assert.Equals(Success, true);
        }

        [TestMethod()]
        public async Task CreateNewEmployeeWithNoAddress()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            EmployeeEntity employee = new EmployeeEntity();
            employee.FName = "Vishnu";
            employee.LName = "KB";
            employee.Gender = "M";
            AddressEntity address = null;
            Task<bool> Result = client.CreateEmployeeAsync(employee, address);
            bool Success = await Result;
            Assert.Equals(Success, false);
        }

        [TestMethod()]
        public async Task CreateNewEmployeeWithAddressNoAddress()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            EmployeeEntity employee = new EmployeeEntity();
            AddressEntity address = new AddressEntity();
            address.Line1 = "UST";
            address.Line2 = "TP Campus";
            address.Phone = "23-322-327272552";
            address.POBox = "1232";
            address.City = "TVM";
            address.Country = "IND";
            address.Email = "vis@kb.com";
            Task<bool> Result = client.CreateEmployeeAsync(employee, address);
            bool Success = await Result;
            Assert.Equals(Success, false);
        }

        [TestMethod()]
        [ExpectedException(typeof(ExceptionFaultContract))]
        public async void CreateEmployeeAsyncTest()
        {
            //arrange
            EmployeeContractClient client = new EmployeeContractClient();
            EmployeeEntity employee = new EmployeeEntity();
            employee.FName = "Vishnu";
            employee.LName = "KB";
            employee.Gender = "M";
            AddressEntity address = new AddressEntity();
            address.Line1 = "UST";
            address.Line2 = "TP Campus";
            address.Phone = "23-322-327272552";
            address.POBox = "1232";
            address.City = "TVM";
            address.Country = "IND";
            address.Email = "vis@kb.com";
            //act
            Task<bool> Result = client.CreateEmployeeAsync(employee, address);
            bool Success = await Result;
            //assert
            Assert.Equals(Success, true);
        }

        [TestMethod()]
        public async void UpdateEmployeeAsyncTest()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            EmployeeEntity employee = new EmployeeEntity();
            AddressEntity address = new AddressEntity();
            address.Line1 = "UST";
            address.Line2 = "TP Campus";
            address.Phone = "23-322-327272552";
            address.POBox = "1232";
            address.City = "TVM";
            address.Country = "IND";
            address.Email = "vis@kb.com";
            Task<bool> Result = client.CreateEmployeeAsync(employee, address);
            bool Success = await Result;
            Assert.Equals(Success, true);
           
        }

        [TestMethod()]
        public async void GetEmployeeAsyncTest()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            Task<EmployeeEntity> Result = client.GetEmployeeAsync(8);
            EmployeeEntity employee = await Result;
            Assert.IsNotNull(employee);
        }

        [TestMethod()]
        public async void GetAllEmployeesAsyncTest()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            Task<EmployeeEntity[]> Result = client.GetAllEmployeesAsync();
            EmployeeEntity[] employeeList = await Result;
            Assert.IsNotNull(employeeList);
        }

        [TestMethod()]
        public async void DeleteEmployeeAsyncTest()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            Task<bool> Result = client.DeleteEmployeeAsync(new EmployeeEntity() { ID = 8 });
            bool Success = await Result;
            Assert.AreEqual(Success, true);
        }

        [TestMethod()]
        public async void UpdateAddressAsyncTest()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            AddressEntity address = new AddressEntity();
            address.Line1 = "UST";
            address.Line2 = "TP Campus";
            address.Phone = "23-322-327272552";
            address.POBox = "1232";
            address.City = "TVM";
            address.Country = "IND";
            address.Email = "vis@kb.com";
            address.EmployeeID = 8;
            Task<bool> Result = client.UpdateAddressAsync(address);
            bool Success = await Result;
            Assert.AreEqual(Success, true);
        }

        [TestMethod()]
        public async void DeleteAddressAsyncTest()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            Task<bool> Result = client.DeleteAddressAsync(new AddressEntity() { AddressID = 8 });
            bool Success = await Result;
            Assert.AreEqual(Success, true);
        }

        [TestMethod()]
        public async void GetAddressAsyncTest()
        {
            EmployeeContractClient client = new EmployeeContractClient();
            Task<AddressEntity> Result = client.GetAddressAsync(8);
            AddressEntity AddressEntity = await Result;
        }
    }
}