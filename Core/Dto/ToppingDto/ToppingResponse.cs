using Core.Domain.Entities;

namespace Core.Dto.ToppingDto
{
    public class ToppingResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public static class ToppingExtension
    {
        public static ToppingResponse ToToppingResponse(this Topping? topping)
        {
            if (topping == null)
                return new ToppingResponse();

            return new ToppingResponse
            {
                Id = topping.Id,
                Name = topping.Name
            };
        }
    }
}
