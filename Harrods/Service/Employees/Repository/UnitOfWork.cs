using Harrods.Service.Employees.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Unit of Work Implementation for HarrodsContext
/// </summary>
namespace Harrods.Service.Employees.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HarrodsContext _harrodsContext;
        private IRepository<Employee> _employeeRepository;
        private IRepository<Address> _addressRepositoryRepository;

        public UnitOfWork(HarrodsContext employeeContext)
        {
            _harrodsContext = employeeContext;
        }

        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                return _employeeRepository = _employeeRepository ?? new GenericRepository<Employee>(_harrodsContext);
            }
        }

        public IRepository<Address> AddressRepository
        {
            get
            {
                return _addressRepositoryRepository = _addressRepositoryRepository ?? new GenericRepository<Address>(_harrodsContext);
            }
        }

        public async Task<bool> SaveAsync()
        {
            Task<int> Result= _harrodsContext.SaveChangesAsync();
            int data = await Result;
            return true;
        }
    }
}
