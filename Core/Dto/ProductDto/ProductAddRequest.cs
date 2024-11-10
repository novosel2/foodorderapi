using Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Dto.ProductDto
{
    public class ProductAddRequest
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price can not be less than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Product type id is required.")]
        public Guid ProductTypeId { get; set; }

        public Guid? MeatTypeId { get; set; }

        public Product ToProduct()
        {
            return new Product()
            {
                Name = Name,
                Description = Description,
                Price = Price,
                ProductTypeId = ProductTypeId,
                MeatTypeId = MeatTypeId
            };
        }
    }
}
