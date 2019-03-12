using Harrods.Service.Employees.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Unit of Work Interface for HarrodsContext
/// </summary>
namespace Harrods.Service.Employees.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Address> AddressRepository { get; }
        Task<bool> SaveAsync();
    }
}
