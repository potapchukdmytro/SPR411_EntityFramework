namespace _02_relationships_seeder.Entites
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Many-to-Many Relationship with User
        public virtual List<User> Users { get; set; } = [];
    }
}
