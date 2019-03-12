using Harrods.Service.Employees.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///  Unit of work implementaion for the specified entity class Address
///  Here we can calls the Data Access layer functions. 
///  Invokes IQuerryable statements etc.
/// </summary>
namespace Harrods.Service.Employees.Repository
{
    public class AddressRepository : IRepository<Address>
    {
        private IRepository<Address> addressRepo = null;

        public AddressRepository(IRepository<Address> repository)
        {
            addressRepo = repository;
        }
        public async Task<bool> Delete(Address Address)
        {
            return await addressRepo.Delete(Address);
        }
        public async Task<bool> Update(Address Address)
        {
            return await addressRepo.Update(Address);
        }
        public async Task<Address> Find(int id)
        {
            return await addressRepo.Find(id);
        }

        public Task<IEnumerable<Address>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Address Address)
        {
            throw new NotImplementedException();
        }


    }
}
