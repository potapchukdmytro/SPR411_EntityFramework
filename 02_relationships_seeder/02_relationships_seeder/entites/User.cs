namespace _02_relationships_seeder.Entites
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // One-to-Many Relationship with Order
        public virtual List<Order> Orders { get; set; } = []; // Navigation Property

        // Many-to-Many Relationship with Role
        public virtual List<Role> Roles { get; set; } = [];
    }
}
