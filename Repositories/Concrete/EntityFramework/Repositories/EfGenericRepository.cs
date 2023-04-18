using Microsoft.EntityFrameworkCore;
using Models.Interface;
using Repositories.Concrete.EntityFramework.Context;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EntityFramework.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        protected readonly DbContext _context;
        public EfGenericRepository(DbContext context)
        {
            _context = context; 
        }
        public async Task AddAsync(TEntity entity)
        {
            //using var context = new KoruProjeContext();
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            //using var context = new KoruProjeContext();
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            //using var context = new KoruProjeContext();

            return await _context.Set<TEntity>().ToListAsync();
        }

    
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            //using var context = new KoruProjeContext();
            return await _context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            //using var context = new KoruProjeContext();
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            //using var context = new KoruProjeContext();
            return filter == null
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().Where(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            //using var context = new KoruProjeContext();
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            //using var context = new KoruProjeContext();
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
