using OrderManagementAPI.Application.DTOs;

namespace OrderManagementAPI.Application.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> CreateOrderAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(int page = 1, int pageSize = 10);
        Task<IEnumerable<OrderDTO>> GetOrdersByStatusAsync(string status);
        Task AddProductToOrderAsync(int orderId, AddProductToOrderRequest request);
        Task RemoveProductFromOrderAsync(int orderId, int productId);
        Task CloseOrderAsync(int orderId);
    }
}
