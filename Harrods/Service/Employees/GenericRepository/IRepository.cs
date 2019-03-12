using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Generic interface to perform crud operations
/// </summary>
namespace Harrods.Service.Employees.GenericRepository
{
    
    public interface IRepository<T> where T : class  
    {
        Task<T> Find(int id);
        Task<bool> Save(T employee);
        Task<bool> Delete(T employee);
        Task<bool> Update(T employee);
        Task<IEnumerable<T>> FindAll();
    }
}
