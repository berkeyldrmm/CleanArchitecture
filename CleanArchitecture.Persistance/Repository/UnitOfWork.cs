using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly CleanArchDbContext _context;

    public UnitOfWork(CleanArchDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
