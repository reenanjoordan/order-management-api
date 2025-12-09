namespace OrderManagementAPI.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;  // ← Adicione isto
        public decimal Total { get; set; }
        public List<OrderItemDTO> Items { get; set; } = new();
    }

    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;  // ← Adicione isto
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
