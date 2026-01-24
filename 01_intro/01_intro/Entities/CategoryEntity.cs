namespace _01_intro.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"{Id}: {Name}\nImage: {ImageUrl}\nCreate date: {CreateDate}";
        }
    }
}
