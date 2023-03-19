using System;
namespace ThinkBridgeShop.Infrastructure.Interfaces
{
	public interface IRepositoryAsync<T>
	{
        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(int Page,int PageSize);


        Task<bool> ExistsAsync(object id);
    }
}

