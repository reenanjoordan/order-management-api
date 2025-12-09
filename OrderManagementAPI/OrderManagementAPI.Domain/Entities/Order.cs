namespace OrderManagementAPI.Domain.Entities
{
    public enum OrderStatus
    {
        Open = 0,
        Closed = 1
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new();

        public Order()
        {
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Open;
        }

        public void AddItem(Product product, int quantity)
        {
            if (Status == OrderStatus.Closed)
                throw new InvalidOperationException("Cannot add products to a closed order");

            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new OrderItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }
        }

        public void RemoveItem(int productId)
        {
            if (Status == OrderStatus.Closed)
                throw new InvalidOperationException("Cannot remove products from a closed order");

            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
                Items.Remove(item);
        }

        public void Close()
        {
            if (Items.Count == 0)
                throw new InvalidOperationException("Cannot close an order without items");

            Status = OrderStatus.Closed;
        }

        public decimal GetTotal() => Items.Sum(i => i.Price * i.Quantity);
    }
}
