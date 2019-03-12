using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Harrods.Service.Employees.Contracts;
using Harrods.Service.Employees.Entities;
using Harrods.Service.Employees.Facade;
using Harrods.Service.Employees.Repository;

/// <summary>
/// Service Implementation layer. This will invoke the functions exposed by Facade
/// and catches exceptions and generates Faults. The faults will be send to client.
/// </summary>
namespace Harrods.Service.Employees.Implementation
{
    public class EmployeeImpl : IEmployeeContract
    {
        private EmployeeFacade _employeeFacade = null;
      
        public EmployeeImpl(IUnitOfWork unitOfWork)
        {
            _employeeFacade = new EmployeeFacade(unitOfWork);
        }

        public async Task<bool> CreateEmployeeAsync(EmployeeEntity Employee, AddressEntity address)
        {
            try
            {
                Task<bool> task=   _employeeFacade.CreateEmployeeAsync(Employee, address);
                bool result = await task;
                return result;
            }
            catch(Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
          
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeEntity Employee)
        {
           
            try
            {
                Task<bool> task = _employeeFacade.UpdateEmployeeAsync(Employee);
                bool result = await task;
                return result;
            }
            catch (Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
        }

        public async Task<EmployeeEntity> GetEmployeeAsync(int ID)
        {
            try
            {
                Task<EmployeeEntity> task = _employeeFacade.GetEmployeeAsync(ID);
                EmployeeEntity result = await task;
                return result;
            }
            catch (Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync()
        {
            try
            {
                Task<IEnumerable<EmployeeEntity>> task = _employeeFacade.GetAllEmployeesAsync();
                IEnumerable<EmployeeEntity> result = await task;
                return result;
            }
            catch (Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
        }
         
        public async Task<bool> DeleteEmployeeAsync(EmployeeEntity EmployeeEntity)
        {
            try
            {                
                Task<bool> task = _employeeFacade.DeleteEmployeeAsync(EmployeeEntity);
                bool result = await task;
                return result;
            }
            catch (Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
        }

        public async Task<bool> UpdateAddressAsync(AddressEntity Address)
        {
            try
            {
                Task<bool> task = _employeeFacade.UpdateAddressAsync(Address);
                bool result = await task;
                return result;
            }
            catch (Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
        }

        public async Task<bool> DeleteAddressAsync(AddressEntity Address)
        {
            try
            {
                Task<bool> task = _employeeFacade.DeleteAddressAsync(Address);
                bool result = await task;
                return result;
            }
            catch (Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
        }

        public async Task<AddressEntity> GetAddressAsync(int AddressID)
        {
            try
            {
                Task<AddressEntity> task = _employeeFacade.GetAddressAsync(AddressID);
                AddressEntity AddressEntity = await task;
                return AddressEntity;
            }
            catch (Exception exception)
            {
                ExceptionFaultContract exceptionFaultContract = new ExceptionFaultContract();
                exceptionFaultContract.Message = exception.Message;
                exceptionFaultContract.StackTrace = exception.StackTrace;
                exceptionFaultContract.Source = exception.Source;
                exceptionFaultContract.BaseException = exception.GetBaseException().GetType().FullName;
                throw new FaultException<ExceptionFaultContract>(exceptionFaultContract, new FaultReason(exception.Message));
            }
        }
       
    }

}
