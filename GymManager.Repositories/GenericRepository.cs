using System.Linq.Expressions;
using GymManager.Entities;
using GymManager.Entities.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GymManager.Repositories
{
    public abstract class GenericRepository<T, TId> : IGenericRepository<T, TId>
    where T : EntityBase
    where TId : IEquatable<TId>
    {
        private readonly GymManagerDbContext _context;
        protected DbSet<T> Entities => _context.Set<T>();

        protected GenericRepository(GymManagerDbContext context)
        {
            _context = context;
        }

        public async Task<T> Insert(T entity)
        {
            entity.RegistrationDate = DateTime.UtcNow;
            entity.LastUpdateUtc = DateTime.MinValue;
            entity.DeletedTimeUtc = DateTime.MinValue;
            entity.Active = true;

            EntityEntry<T> insertedValue = await _context.Set<T>().AddAsync(entity);
            return insertedValue.Entity;
        }

        public async Task<T?> GetById(TId id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<TId>(e, "Id").Equals(id));
            //return await Entities.FindAsync(id);
        }

        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
            //return _context.Set<T>();
        }

        public void Update(T entity)
        {
            entity.LastUpdateUtc = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
        }

        public async Task<bool> SoftDelete(TId id)
        {
            T? entity = await GetById(id);

            if (entity is null)
                return false;

            entity.IsDeleted = true;
            entity.DeletedTimeUtc = DateTime.UtcNow;

            _context.Set<T>().Update(entity);
            return true;
        }

        public async Task<bool> HardDelete(TId id)
        {
            T? entity = await GetById(id);
            if (entity is null)
                return false;
            _context.Set<T>().Remove(entity);
            return true;
        }
    }
}

