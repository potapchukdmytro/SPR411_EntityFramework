namespace _02_relationships_seeder.Entites
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // One-to-Many Relationship with OrderItem
        public virtual List<OrderItem> OrderItems { get; set; } = []; // Navigation Property

        public int UserId { get; set; } // Foreign Key
        public virtual User? User { get; set; } // Navigation Property
    }
}
