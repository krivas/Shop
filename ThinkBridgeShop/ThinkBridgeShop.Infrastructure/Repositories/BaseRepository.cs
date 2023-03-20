using System;
using Microsoft.EntityFrameworkCore;
using ThinkBridgeShop.Infrastructure.Context;
using ThinkBridgeShop.Application.Contracts.Repositories;

namespace ThinkBridgeShop.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ThinkBridgeShopContext _context;
        public BaseRepository(ThinkBridgeShopContext context) => _context = context;
 

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> ExistsAsync(object id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page,int pageSize)
        {
            return await _context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}

