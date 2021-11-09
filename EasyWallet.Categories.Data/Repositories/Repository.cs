﻿using EasyWallet.Categories.Data.Abstractions;
using EasyWallet.Categories.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            var savedEntity = await Context.Set<TEntity>().AddAsync(entity);
            return savedEntity.Entity.Id;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }
    }
}
