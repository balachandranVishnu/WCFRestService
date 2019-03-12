using Harrods.Service.Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harrods.Service.Employees.Repository;

using AutoMapper;
using System.Data.SqlClient;
using Harrods.Service.Employees.BussinessValidations;
namespace Harrods.Service.Employees.Bussiness
{
    public class EmployeeBL
    {
        private IUnitOfWork _unitOfWork = null;
        
        public EmployeeBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateEmployeeAsync(EmployeeEntity EmployeeEntity, AddressEntity AddressEntity)
        {
            try
            {
                ValidationRules.ValidateAddressRules(AddressEntity);                
                Employee employee = new Employee()
                {
                    FName = EmployeeEntity.FName,
                    LName = EmployeeEntity.LName,
                    Gender = EmployeeEntity.Gender,
                    CreatedTime = DateTime.Now
                };
                Address address = new Address()
                {
                    Line1 = AddressEntity.Line1,
                    Line2 = AddressEntity.Line2,
                    POBox = AddressEntity.POBox,
                    City = AddressEntity.City,
                    Phone = AddressEntity.Phone,
                    Email = AddressEntity.Email,
                    Country = AddressEntity.Country
                };
                employee.Address = address;
                Task<bool> Result = _unitOfWork.EmployeeRepository.Save(employee);
                bool Success = await Result;
                Result = _unitOfWork.SaveAsync();
                Success = await Result;
                return Success;
            }
            catch(Exception exception)
            {
                Exception baseException = exception.GetBaseException();
                if (exception.GetBaseException() is SqlException sqlException)
                {
                    if (((SqlException)baseException).Number == 2627)
                        throw new Exception("Error while saving as the phone number entered is already registered.");
                }                
                throw;
            }

        }
        public async Task<bool> UpdateEmployeeAsync(EmployeeEntity EmployeeEntity)
        {
            Employee employee = new Employee()
            {
                FName = EmployeeEntity.FName,
                LName = EmployeeEntity.LName,
                Gender = EmployeeEntity.Gender,
                EmpID=  EmployeeEntity.ID,
                UpdatedTime = DateTime.Now
            };
            Task<bool> Result = _unitOfWork.EmployeeRepository.Save(employee);
            bool Success = await Result;
            Result = _unitOfWork.SaveAsync();
            Success = await Result;
            return Success; 
        }
        public async Task<EmployeeEntity> GetEmployeeAsync(int ID)
        {
           Task<Employee> task= _unitOfWork.EmployeeRepository.Find(ID);
            Employee employee = await task;
            return new EmployeeEntity()
            {
                ID = employee.EmpID,
                FName = employee.FName,
                LName = employee.LName,
                Gender = employee.Gender
            };
        }
        public async Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync()
        {
            Task<IEnumerable<Employee>> task = _unitOfWork.EmployeeRepository.FindAll();
            IEnumerable<Employee> employeeList = await task;
            List<EmployeeEntity> employeeEntityList = new List<EmployeeEntity>();
            employeeList.ToList().ForEach(employee =>
            {
                employeeEntityList.Add(new EmployeeEntity()
                {
                    ID = employee.EmpID,
                    FName = employee.FName,
                    LName = employee.LName,
                    Gender = employee.Gender
                });
            });
            return employeeEntityList;
        }
        public async Task<bool> DeleteEmployeeAsync(EmployeeEntity EmployeeEntity)
        {
            Employee employee = new Employee()
            {
                EmpID = EmployeeEntity.ID
            };
            Task<Employee> getEmployee= _unitOfWork.EmployeeRepository.Find(EmployeeEntity.ID);
            employee = await getEmployee;
            Task<bool> Result = _unitOfWork.AddressRepository.Delete(employee.Address);
            bool Success = await Result;
            Result = _unitOfWork.EmployeeRepository.Delete(employee);
            Success = await Result;
            Result = _unitOfWork.SaveAsync();
            Success = await Result;
            return Success;
        }
    }
}
