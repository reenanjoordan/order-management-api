namespace OrderManagementAPI.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;  // ← Adicione isto
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Order? Order { get; set; }  // ← Adicione ? para nullable
    }
}
