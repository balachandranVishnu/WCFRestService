using Harrods.Service.Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harrods.Service.Employees.Bussiness;
using Harrods.Service.Employees.Repository;

/// <summary>
///  Facade layer will acts as an junction between multiple sub layers or services.
///  Here this layer communicates with Bussiness layer.
/// </summary>
namespace Harrods.Service.Employees.Facade
{
    public class EmployeeFacade
    {

        private EmployeeBL _employeeBL = null;
        private AddressBL _addressBL = null;

        
        public EmployeeFacade(IUnitOfWork unitOfWork)
        {
            _employeeBL = new EmployeeBL(unitOfWork);
            _addressBL = new AddressBL(unitOfWork);
        }
        public async Task<bool> CreateEmployeeAsync(EmployeeEntity EmployeeEntity, AddressEntity AddressEntity)
        {            
            return await _employeeBL.CreateEmployeeAsync(EmployeeEntity, AddressEntity);
             
        }
        public async Task<bool> UpdateEmployeeAsync(EmployeeEntity Employee)
        {
            return await _employeeBL.UpdateEmployeeAsync(Employee);
        }
        public async Task<EmployeeEntity> GetEmployeeAsync(int ID)
        {
            return await _employeeBL.GetEmployeeAsync(ID);
        }
        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync()
        {
            return await _employeeBL.GetEmployeesAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(EmployeeEntity Employee)
        {
            return await _employeeBL.DeleteEmployeeAsync(Employee);
        }

        public async Task<bool> UpdateAddressAsync(AddressEntity Address)
        {
            return await _addressBL.UpdateAddressAsync(Address);
        }

        public async Task<bool> DeleteAddressAsync(AddressEntity Address)
        {
            return await _addressBL.DeleteAddressAsync(Address);
        }

        public async Task<AddressEntity> GetAddressAsync(int AddressID)
        {
            return await _addressBL.GetAddressAsync(AddressID);
        }
    }
}
