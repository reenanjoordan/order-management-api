namespace OrderManagementAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // ← Adicione isto
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product() { }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
