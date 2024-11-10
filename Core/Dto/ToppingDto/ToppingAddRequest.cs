using Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Dto.ToppingDto
{
    public class ToppingAddRequest
    {
        [Required]
        public string? Name { get; set; }

        public Topping ToTopping()
        {
            return new Topping()
            {
                Name = Name
            };
        }
    }
}
