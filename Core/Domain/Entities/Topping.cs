using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Topping
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<ToppingProduct>? ToppingProducts { get; set; } = [];
    }
}
