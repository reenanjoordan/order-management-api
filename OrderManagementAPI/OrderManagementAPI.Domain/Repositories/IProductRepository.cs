using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
