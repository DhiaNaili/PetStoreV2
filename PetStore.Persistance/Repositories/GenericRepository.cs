using Microsoft.EntityFrameworkCore;
using PetStore.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        private readonly PetStoreDbContext _dbContext;
       
        public GenericRepository(PetStoreDbContext dbConext)
        {
            _dbContext = dbConext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(long id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
             await _dbContext.SaveChangesAsync();
        }
    }
}
