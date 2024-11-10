using Core.Dto.ToppingDto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price can not be less than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Product type id is required.")]
        public Guid ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }

        public Guid? MeatTypeId { get; set; }
        public MeatType? MeatType { get; set; }

        public List<ToppingProduct> ToppingProducts { get; set; } = [];
    }
}
