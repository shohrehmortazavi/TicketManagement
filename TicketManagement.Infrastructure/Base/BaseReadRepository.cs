using TicketManagement.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace TicketManagement.Infrastructure.Base;

public class BaseReadRepository<T>(TicketManagementDbContext context) : IBaseReadRepository<T> where T : BaseEntity
{
    private readonly TicketManagementDbContext _context = context;

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().Where(x => !x.IsDeleted);
    }
}
