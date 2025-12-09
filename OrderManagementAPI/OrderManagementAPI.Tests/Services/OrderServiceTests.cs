using Moq;
using OrderManagementAPI.Application.DTOs;
using OrderManagementAPI.Application.Services;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Domain.Repositories;

namespace OrderManagementAPI.Tests.Services
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _orderService = new OrderService(_mockOrderRepository.Object, _mockProductRepository.Object);
        }

        [Fact(DisplayName = "Should create a new order successfully")]
        public async Task CreateOrder_WhenCalled_ShouldReturnOrderDTO()
        {
            // Arrange
            var order = new Order { Id = 1 };
            _mockOrderRepository.Setup(r => r.AddAsync(It.IsAny<Order>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _orderService.CreateOrderAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(OrderStatus.Open.ToString(), result.Status);
            _mockOrderRepository.Verify(r => r.AddAsync(It.IsAny<Order>()), Times.Once);
        }

        [Fact(DisplayName = "Should get order by id successfully")]
        public async Task GetOrderById_WhenOrderExists_ShouldReturnOrderDTO()
        {
            // Arrange
            var order = new Order { Id = 1 };
            _mockOrderRepository.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(order);

            // Act
            var result = await _orderService.GetOrderByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact(DisplayName = "Should throw exception when order not found")]
        public async Task GetOrderById_WhenOrderNotExists_ShouldThrowException()
        {
            // Arrange
            _mockOrderRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Order)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _orderService.GetOrderByIdAsync(1));
        }

        [Fact(DisplayName = "Should add product to open order")]
        public async Task AddProductToOrder_WhenOrderIsOpen_ShouldAddProduct()
        {
            // Arrange
            var order = new Order { Id = 1, Status = OrderStatus.Open };
            var product = new Product { Id = 1, Name = "Product", Price = 100, Quantity = 10 };
            var request = new AddProductToOrderRequest { ProductId = 1, Quantity = 2 };

            _mockOrderRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(order);
            _mockProductRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);
            _mockOrderRepository.Setup(r => r.UpdateAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);

            // Act
            await _orderService.AddProductToOrderAsync(1, request);

            // Assert
            Assert.Single(order.Items);
            _mockOrderRepository.Verify(r => r.UpdateAsync(It.IsAny<Order>()), Times.Once);
        }

        [Fact(DisplayName = "Should throw exception when adding to closed order")]
public async Task AddProductToOrder_WhenOrderIsClosed_ShouldThrowException()
{
    // Arrange
    var order = new Order { Id = 1, Status = OrderStatus.Closed };
    var product = new Product { Id = 1, Name = "Product", Price = 100, Quantity = 10 };
    var request = new AddProductToOrderRequest { ProductId = 1, Quantity = 2 };

    _mockOrderRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(order);
    _mockProductRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

    // Act & Assert
    await Assert.ThrowsAsync<InvalidOperationException>(() => 
        _orderService.AddProductToOrderAsync(1, request));
}

        [Fact(DisplayName = "Should close order with items")]
        public async Task CloseOrder_WhenOrderHasItems_ShouldChangeStatusToClosed()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product", Price = 100, Quantity = 10 };
            var order = new Order { Id = 1, Status = OrderStatus.Open };
            order.AddItem(product, 2);

            _mockOrderRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(order);
            _mockOrderRepository.Setup(r => r.UpdateAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);

            // Act
            await _orderService.CloseOrderAsync(1);

            // Assert
            Assert.Equal(OrderStatus.Closed, order.Status);
            _mockOrderRepository.Verify(r => r.UpdateAsync(It.IsAny<Order>()), Times.Once);
        }

        [Fact(DisplayName = "Should throw exception when closing empty order")]
        public async Task CloseOrder_WhenOrderEmpty_ShouldThrowException()
        {
            // Arrange
            var order = new Order { Id = 1, Status = OrderStatus.Open };
            _mockOrderRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(order);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _orderService.CloseOrderAsync(1));
        }
    }
}
