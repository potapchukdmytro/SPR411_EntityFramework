namespace _02_relationships_seeder.Entites
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; } // Navigation Property
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public virtual Order? Order { get; set; } // Navigation Property
    }
}
