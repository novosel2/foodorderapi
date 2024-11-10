using Core.Dto.ProductDto;
using System.ComponentModel.DataAnnotations;

namespace Core.Dto.ProductDto
{
    public class ProductUpdateRequest : ProductAddRequest
    {
        [Key]
        public Guid Id { get; set; }
    }
}
