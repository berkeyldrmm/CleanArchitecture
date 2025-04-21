using CleanArchitecture.Domain.Abstractions;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Repositories;

public interface IGenericRepository<T> where T : Entity
{
    IQueryable<TDto> GetAll<TDto>() where TDto : EntityDTO;
    IQueryable<TDto> GetByFilters<TDto>(IEnumerable<Expression<Func<T, bool>>> expressions) where TDto : EntityDTO;
    Task<TDto> GetOneAsync<TDto>(string id);
    Task<bool> AddAsync(T entity, CancellationToken cancellationToken);
    Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    bool UpdateAsync(T entity);
    Task<bool> DeleteAsync(string id);
}
