namespace TicketManagement.Domain.Base;
public interface IBaseReadRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    IQueryable<T> GetAll();
}

