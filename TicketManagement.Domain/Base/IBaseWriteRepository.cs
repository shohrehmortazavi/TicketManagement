namespace TicketManagement.Domain.Base;
public interface IBaseWriteRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    void Update(T entity);
    void SoftDelete(T entity);
    Task SaveChangesAsync();

}

