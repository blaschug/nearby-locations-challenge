using Locations.Domain.Abstractions;

namespace Locations.Application.Commons.Interfaces.Persistance
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task InsertAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}