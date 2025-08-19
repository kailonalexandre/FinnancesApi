using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error retrieving all entities.", ex);
            }
        }
        public virtual async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (entity == null)
                    throw new InvalidOperationException("Entity not found.");
                return entity;
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Invalid ID provided.", ex);
            }
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();

                entity.CreateAt = DateTime.UtcNow;
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error generating new ID for entity.", ex);
            }
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(p => p.Id == entity.Id);
                if (result == null)
                    throw new InvalidOperationException("Entity not found for update.");

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt; // Preserve original creation date

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating entity.", ex);
            }

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                    return false;

                _dbSet.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting entity.", ex);
            }

        }
        
    }
}