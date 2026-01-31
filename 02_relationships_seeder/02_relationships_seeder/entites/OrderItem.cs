namespace _02_relationships_seeder.entites
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; } // Navigation Property
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; } // Navigation Property
    }
}
