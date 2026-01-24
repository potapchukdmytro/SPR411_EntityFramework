using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_intro.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public required string Title { get; set; }
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"{Id}: {Title}\nPrice: {Price} грн.";
        }
    }
}
