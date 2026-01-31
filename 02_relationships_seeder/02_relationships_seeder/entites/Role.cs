namespace _02_relationships_seeder.entites
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Many-to-Many Relationship with User
        public List<User> Users { get; set; } = [];
    }
}
