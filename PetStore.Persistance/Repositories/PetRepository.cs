using Microsoft.EntityFrameworkCore;
using PetStore.Application.Contracts.Persistance;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Persistance.Repositories
{
    public class PetRepository : GenericRepository<Pet> ,IPetRepository
    {
        private readonly PetStoreDbContext _dbContext;
        public PetRepository(PetStoreDbContext dbContext) :base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Pet>> GetPetsByStatus(string status)
        {
            return await _dbContext.Pets
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .Where(p => p.Status == status)
                .ToListAsync();
        }
    }
}
