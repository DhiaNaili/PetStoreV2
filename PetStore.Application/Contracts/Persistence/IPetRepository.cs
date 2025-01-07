using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Contracts.Persistance
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        Task<IReadOnlyList<Pet>> GetPetsByStatus(string status);
    }
}
