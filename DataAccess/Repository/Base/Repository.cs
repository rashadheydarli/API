using System;
using Common.Entitties;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);  //updatein asnyc i olmadigi ucun Task yox void olur 
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
    }
}

