using System;
namespace ThinkBridgeShop.Infrastructure.Interfaces
{
	public interface IRepository<T>
	{
        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<IEnumerable<T>> GetAll();


        Task<bool> ExistsAsync(object id);
    }
}

