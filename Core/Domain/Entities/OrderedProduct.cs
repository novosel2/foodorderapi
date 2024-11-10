using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities
{
    public class OrderedProduct
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        public List<OrderedProductTopping> OrderedProductToppings { get; set; } = [];
    }
}
