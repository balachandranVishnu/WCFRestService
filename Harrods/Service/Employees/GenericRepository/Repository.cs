using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Implementation of genric repository.
/// Mainly throws DbEntityValidationException
/// </summary>
namespace Harrods.Service.Employees.GenericRepository
{

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(T data)
        {
            try
            {
                _dbContext.Set<T>().Remove(data);
                int x = await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbEntityValidationException exception)
            {
                StringBuilder validationErrors = new StringBuilder();
                exception.EntityValidationErrors.ToList().ForEach(entityValidationErrors =>
                {
                    entityValidationErrors.ValidationErrors.ToList().ForEach(error =>
                    {
                        validationErrors.Append(error.ErrorMessage);
                    });
                });
                throw new DbEntityValidationException(validationErrors.ToString());

            }
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            List<T> T = await _dbContext.Set<T>().ToListAsync();
            return T;
        }

        public async Task<T> Find(int id)
        {
            T T = await _dbContext.Set<T>().FindAsync(id);
            return T;
        }

        public async Task<bool> Save(T data)
        {
            try
            {
                _dbContext.Set<T>().Add(data);
                int Result = await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbEntityValidationException exception)
            {
                StringBuilder validationErrors = new StringBuilder();
                exception.EntityValidationErrors.ToList().ForEach(entityValidationErrors =>
                {
                    entityValidationErrors.ValidationErrors.ToList().ForEach(error =>
                    {
                        validationErrors.Append(error.ErrorMessage);
                    });
                });
                throw new DbEntityValidationException(validationErrors.ToString());

            }
            
        }

        public async Task<bool> Update(T data)
        {
            try
            {
                _dbContext.Set<T>().Attach(data);
                _dbContext.Entry(data).State = EntityState.Modified;
                int Result = await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbEntityValidationException exception)
            {
                StringBuilder validationErrors = new StringBuilder();
                exception.EntityValidationErrors.ToList().ForEach(entityValidationErrors =>
                {
                    entityValidationErrors.ValidationErrors.ToList().ForEach(error =>
                    {
                        validationErrors.Append(error.ErrorMessage);
                    });
                });
                throw new DbEntityValidationException(validationErrors.ToString());

            }
           
        }
    }
}
