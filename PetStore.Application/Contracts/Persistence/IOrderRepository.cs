using PetStore.Application.Contracts.Persistance;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Contracts.Persistence
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrderById(long id);
        Task<List<Order>> GetOrdersByStatus(string status);


    }
}
