using Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Dto.MeatTypeDto
{
    public class MeatTypeAddRequest
    {
        [Required(ErrorMessage = "Type name is required.")]
        public string? Type { get; set; }

        public MeatType ToMeatType()
        {
            return new MeatType()
            {
                Type = Type,
            };
        }
    }
}
