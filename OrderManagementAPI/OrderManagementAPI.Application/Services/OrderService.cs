using OrderManagementAPI.Application.DTOs;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Domain.Repositories;

namespace OrderManagementAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderDTO> CreateOrderAsync()
        {
            var order = new Order();
            await _orderRepository.AddAsync(order);
            return MapToDTO(order);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                throw new KeyNotFoundException($"Order {id} not found");

            return MapToDTO(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(int page = 1, int pageSize = 10)
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(MapToDTO)
                .ToList();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByStatusAsync(string status)
        {
            if (!Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                throw new ArgumentException("Invalid status");

            var orders = await _orderRepository.GetByStatusAsync(orderStatus);
            return orders.Select(MapToDTO).ToList();
        }

        public async Task AddProductToOrderAsync(int orderId, AddProductToOrderRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Order {orderId} not found");

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new KeyNotFoundException($"Product {request.ProductId} not found");

            order.AddItem(product, request.Quantity);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task RemoveProductFromOrderAsync(int orderId, int productId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Order {orderId} not found");

            order.RemoveItem(productId);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task CloseOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Order {orderId} not found");

            order.Close();
            await _orderRepository.UpdateAsync(order);
        }

        private OrderDTO MapToDTO(Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Status = order.Status.ToString(),
                Total = order.GetTotal(),
                Items = order.Items.Select(i => new OrderItemDTO
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}
