using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harrods.Service.Employees.GenericRepository;

/// <summary>
///  Unit of work implementaion for the specified entity class Employee
///  Here we can calls the Data Access layer functions. 
///  Invokes IQuerryable statements etc.
/// </summary>
namespace Harrods.Service.Employees.Repository
{
    public class EmployeRepository : IRepository<Employee>
    {
        private IRepository<Employee> employeeRepo = null;
      
        public EmployeRepository(IRepository<Employee> repository)
        {
            employeeRepo = repository;
        }

        async Task<bool> IRepository<Employee>.Delete(Employee employee)
        {
            return await employeeRepo.Delete(employee);
        }

        async Task<IEnumerable<Employee>> IRepository<Employee>.FindAll()
        {
            return await employeeRepo.FindAll();
        }
               
        async Task<Employee> IRepository<Employee>.Find(int id)
        {
            return await employeeRepo.Find(id);
        }
                
        async Task<bool> IRepository<Employee>.Save(Employee employee)
        {
            return await employeeRepo.Save(employee);
        }

        async Task<bool> IRepository<Employee>.Update(Employee employee)
        {
            return await employeeRepo.Update(employee);
        }
    }
}
