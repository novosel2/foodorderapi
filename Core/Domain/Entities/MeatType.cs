using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class MeatType
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Type name is required.")]
        public string? Type { get; set; }
    }
}
