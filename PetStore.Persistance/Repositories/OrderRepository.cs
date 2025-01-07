using Microsoft.EntityFrameworkCore;
using PetStore.Application.Contracts.Persistance;
using PetStore.Application.Contracts.Persistence;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Persistance.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly PetStoreDbContext _dbContext;
        public OrderRepository(PetStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> GetOrderById(long id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }
        public async Task<List<Order>> GetOrdersByStatus(string status)
        {
            return await _dbContext.Orders.Where(o => o.Status == status).ToListAsync();
        }
    }
}
