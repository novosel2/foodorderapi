using Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Dto.ProductTypeDto
{
    public class ProductTypeAddRequest
    {
        [Required(ErrorMessage = "Type name is required.")]
        public string? Type { get; set; }

        public ProductType ToProductType()
        {
            return new ProductType()
            {
                Type = Type
            };
        }
    }
}
