using TicketManagement.Domain.Base;

namespace TicketManagement.Infrastructure.Base;

public class BaseWriteRepository<T>(TicketManagementDbContext context) : IBaseWriteRepository<T> where T : BaseEntity
{
    private readonly TicketManagementDbContext _context = context;

    public async Task<T> AddAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var resultEntity = await _context.Set<T>().AddAsync(entity);
        return resultEntity.Entity;
    }
    public void Update(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        entity.SetUpdateTime();
        _context.Set<T>().Update(entity);
    }

    public void SoftDelete(T entity)
    {
        entity.SetAsDeleted();
        entity.Deactivate();
        entity.SetUpdateTime();

        _context.Set<T>().Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
