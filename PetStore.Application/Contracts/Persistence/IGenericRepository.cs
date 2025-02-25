﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Add(T entity);  
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(long id);
    }
}
