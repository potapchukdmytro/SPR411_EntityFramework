namespace _02_relationships_seeder.entites
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // One-to-Many Relationship with Order
        public List<Order> Orders { get; set; } = []; // Navigation Property

        // Many-to-Many Relationship with Role
        public List<Role> Roles { get; set; } = [];
    }
}
