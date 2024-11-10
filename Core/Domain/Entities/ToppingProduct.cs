using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class ToppingProduct
    {
        [Required(ErrorMessage = "ProductId is required")]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        [Required(ErrorMessage = "ToppingId is required")]
        public Guid ToppingId { get; set; }
        public Topping? Topping { get; set; }
    }
}