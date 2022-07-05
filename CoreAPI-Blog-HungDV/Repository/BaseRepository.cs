using CoreAPI_Blog_HungDV.Dal;
using CoreAPI_Blog_HungDV.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Repository
{
    public abstract class BaseRepository 
    {
        private readonly EntityContext _ctx;

        /// <summary>
        /// Initialization Base Repository
        /// </summary>
        /// <param name="ctx"></param>
        public BaseRepository(EntityContext ctx)
        {
            this._ctx = ctx;
        }

        /// <summary>
        /// get all entity in DataBase
        /// </summary>
        /// <returns>List<BaseEntity></returns>
        public async Task<List<BaseEntity>> GetAllEntityAsync()
        {
            string type = this.GetType().Name;
            List<BaseEntity> baseEntities = new List<BaseEntity>();
            if (type.Equals("BlogRepository"))
            {
                foreach (var blog in await _ctx.Blogs.ToListAsync())
                {
                    baseEntities.Add(blog);
                }
            }
            else
            {
                foreach (var blog in await _ctx.PositionItems.ToListAsync())
                {
                    baseEntities.Add(blog);
                }
            }
            return baseEntities;
        }

        /// <summary>
        /// Get Entity By Id in Data Base
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BaseEntity</returns>
        public async Task<BaseEntity> GetEntityByIdAsync(int id)
        {
            BaseEntity entity;
            string type = this.GetType().Name;
            if (type.Equals("BlogRepository"))
            {
                entity = await _ctx.Blogs.FindAsync(id);
            }
            else
            {
                entity = await _ctx.PositionItems.FindAsync(id);
            }
            if (entity == null)
            {
                return new Blog();
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// Create Entity
        /// </summary>
        /// <param name="baseEntity"></param>
        /// <returns>BaseEntity</returns>
        public async Task<BaseEntity> CreateEntityAsync(BaseEntity baseEntity)
        {
            string type = baseEntity.GetType().Name;
            if (type.Equals("Blog"))
            {
                _ctx.Blogs.Add(baseEntity as Blog);
            }
            else
            {
                _ctx.PositionItems.Add(baseEntity as PositionItem);
            }
            await _ctx.SaveChangesAsync();
            return baseEntity;
        }

        /// <summary>
        /// Update Entity in DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="baseEntity"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateEntityAsync(int id, BaseEntity baseEntity)
        {
            string type = baseEntity.GetType().Name;
            try
            {
                baseEntity.Id = id;
                _ctx.Entry(baseEntity).State = EntityState.Modified;
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Entity in DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteEntity(int id)
        {
            bool result = false;
            string type = this.GetType().Name;
            if (type.Equals("BlogRepository"))
            {
                if (BlogExists(id))
                {
                    Blog blog = await GetEntityByIdAsync(id) as Blog;
                    try
                    {
                        _ctx.Blogs.Remove(blog);
                        await _ctx.SaveChangesAsync();
                        result = true;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            else
            {
                if (PositionItemExists(id))
                {
                    PositionItem positionItem = await GetEntityByIdAsync(id) as PositionItem;
                    try
                    {
                        _ctx.PositionItems.Remove(positionItem);
                        await _ctx.SaveChangesAsync();
                        result = true;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Check Blog exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool BlogExists(int id)
        {
            return _ctx.Blogs.Any(e => e.Id == id);
        }

        /// <summary>
        /// Check PositionItem exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool PositionItemExists(int id)
        {
            return _ctx.PositionItems.Any(e => e.Id == id);
        }
    }
}
