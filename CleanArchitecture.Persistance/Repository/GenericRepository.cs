using AutoMapper;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Persistance.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly CleanArchDbContext _context;
        private readonly IMapper _mapper;
        protected GenericRepository(CleanArchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DbSet<T> Entity => _context.Set<T>();

        public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken)
        {
            var entry = await Entity.AddAsync(entity, cancellationToken);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                var entry = await Entity.AddAsync(entity, cancellationToken);
                if (entry.State != EntityState.Added)
                    return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            T entity = await Entity.FirstOrDefaultAsync(x => x.Id == id);
            var entry = Entity.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public IQueryable<TDto> GetAll<TDto>() where TDto : EntityDTO
        {
            return Entity.Select(e => _mapper.Map<T, TDto>(e));
        }

        public IQueryable<TDto> GetByFilters<TDto>(IEnumerable<Expression<Func<T, bool>>> expressions) where TDto : EntityDTO
        {
            IQueryable<T> query = Entity;
            foreach (var ex in expressions)
            {
                query = query.Where(ex);
            }

            return query.Select(e => _mapper.Map<T, TDto>(e));
        }

        public async Task<TDto> GetOneAsync<TDto>(string id)
        {
            return await Entity.Where(x => x.Id == id).Select(e => _mapper.Map<T, TDto>(e)).FirstOrDefaultAsync();
        }

        public bool UpdateAsync(T entity)
        {
            var entry = Entity.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}
