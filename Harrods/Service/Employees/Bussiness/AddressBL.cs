using Harrods.Service.Employees.Entities;
using Harrods.Service.Employees.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harrods.Service.Employees.Bussiness
{
    public class AddressBL
    {
        private IUnitOfWork _unitOfWork = null;
       
        public AddressBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> DeleteAddressAsync(AddressEntity AddressEntity)
        {
            Address address = new Address()
            {
                AddressID = AddressEntity.AddressID,
                //City = AddressEntity.City,
                //Country = AddressEntity.Country,
                //Email = AddressEntity.Email,
                //EmpID = AddressEntity.EmployeeID,
                //Line1 = AddressEntity.Line1,
                //Line2 = AddressEntity.Line2,
                //Phone = AddressEntity.Phone,
                //POBox = AddressEntity.POBox
            };
            Task<bool> Data= _unitOfWork.AddressRepository.Delete(address);
            bool Result = await _unitOfWork.SaveAsync();
            return Result;
        }
        public async Task<bool> UpdateAddressAsync(AddressEntity AddressEntity)
        {
            Address address = new Address()
            {
                AddressID = AddressEntity.AddressID,
                City = AddressEntity.City,
                Country = AddressEntity.Country,
                Email = AddressEntity.Email,
                EmpID = AddressEntity.EmployeeID,
                Line1 = AddressEntity.Line1,
                Line2 = AddressEntity.Line2,
                Phone = AddressEntity.Phone,
                POBox = AddressEntity.POBox
            };
            Task<bool> Result = _unitOfWork.AddressRepository.Update(address);            
            bool Success = await Result;
            Result = _unitOfWork.SaveAsync();
            Success = await Result;
            return Success;
        }
        public async Task<AddressEntity> GetAddressAsync(int AddressID)
        {
             
            Task<Address> Data = _unitOfWork.AddressRepository.Find(AddressID);
            Address address = await Data;
            AddressEntity AddressEntity = new AddressEntity()
            {
                AddressID = address.AddressID,
                City =    address.City,
                Country = address.Country,
                Email = address.Email,
                EmployeeID = address.EmpID,
                Line1 = address.Line1,
                Line2 = address.Line2,
                Phone = address.Phone,
                POBox = address.POBox
            };
            return AddressEntity;
        }
    }
}
