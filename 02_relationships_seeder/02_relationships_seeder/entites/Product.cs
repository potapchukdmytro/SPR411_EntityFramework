namespace _02_relationships_seeder.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { set; get; } = DateTime.UtcNow;

        // One-to-Many Relationship with Category
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; } // Navigation Property

        // One-to-Many Relationship with OrderItem
        public virtual List<OrderItem> OrderItems { get; set; } = []; // Navigation Property

        public override string ToString()
        {
            return $"{Id}: {Name}. Price: {Price}";
        }
    }
}
