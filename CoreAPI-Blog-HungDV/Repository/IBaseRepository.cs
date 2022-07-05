using CoreAPI_Blog_HungDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Repository
{
    public interface IBaseRepository
    {
        Task<BaseEntity> CreateEntityAsync(BaseEntity baseEntity);
        Task<List<BaseEntity>> GetAllEntityAsync();
        Task<BaseEntity> GetEntityByIdAsync(int id);
        Task<bool> UpdateEntityAsync(int id, BaseEntity baseEntity);
        Task<bool> DeleteEntity(int id);
    }
}
