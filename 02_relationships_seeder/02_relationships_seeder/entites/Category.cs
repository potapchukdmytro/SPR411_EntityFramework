namespace _02_relationships_seeder.entites
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // One-to-Many Relationship with Product
        public List<Product> Products { get; set; } = []; // Navigation Property

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}
