﻿using System;
using Microsoft.EntityFrameworkCore;
using ThinkBridgeShop.Infrastructure.Context;
using ThinkBridgeShop.Infrastructure.Interfaces;

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

        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}

