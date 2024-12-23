using System.ComponentModel.DataAnnotations;

namespace Shgardi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
    }
}
