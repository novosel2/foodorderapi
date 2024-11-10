using Core.Domain.Entities;
using Core.Dto.MeatTypeDto;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/meat")]
    public class MeatTypesController : ControllerBase
    {
        private readonly ILogger<MeatTypesController> _logger;
        private readonly IMeatTypesService _meatTypesService;

        public MeatTypesController(ILogger<MeatTypesController> logger, IMeatTypesService meatTypesService)
        {
            _logger = logger;
            _meatTypesService = meatTypesService;
        }


        // GET: /api/meat

        [HttpGet]
        public async Task<IActionResult> GetMeatTypes()
        {
            _logger.LogInformation("GetMeatTypes action method in MeatTypesController.");

            // Get the list of meat types
            List<MeatType> meatTypes = await _meatTypesService.GetMeatTypesAsync();

            return Ok(meatTypes);
        }


        // POST: /api/meat/post

        [HttpPost("post")]
        public async Task<IActionResult> AddMeatType([FromForm]MeatTypeAddRequest meatTypeAddRequest)
        {
            _logger.LogInformation("AddMeatType action method in MeatTypesController.");

            // Try to add meat type, null if failed
            MeatType? result = await _meatTypesService.AddMeatTypeAsync(meatTypeAddRequest.ToMeatType());

            // If adding failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to add meat type.");
                return Problem(
                    detail: "Failed to add meat type.",
                    statusCode: 500,
                    title: "Adding meat type.");
            }

            return Created();
        }


        // PUT: /api/meat/put

        [HttpPut("put")]
        public async Task<IActionResult> UpdateMeatType([FromForm]MeatType updatedMeatType)
        {
            _logger.LogInformation("UpdateMeatType action method in MeatTypesController.");

            // Try to get existing meat type with id, null if failed
            MeatType? existingMeatType = await _meatTypesService.GetMeatTypeByIdAsync(updatedMeatType.Id);

            // If existing meat type not found, return detailed 404 response
            if (existingMeatType == null)
            {
                _logger.LogWarning($"Meat type not found, ID: {updatedMeatType}");
                return Problem(
                    detail: $"Meat type not found, ID: {updatedMeatType}",
                    statusCode: 404,
                    title: "Meat type search.");
            }

            // Try to update existing meat type, null if failed
            MeatType? result = await _meatTypesService.UpdateMeatTypeAsync(existingMeatType, updatedMeatType);

            // If update failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to update existing meat type.");
                return Problem(
                    detail: "Failed to update existing meat type.",
                    statusCode: 500,
                    title: "Updating meat type.");
            }

            return Ok(result);
        }


        // DELETE: /api/meat/delete/65d375c4-2a7f-4e35-bd78-2d0dd870e97d
        [HttpDelete("delete/{meatTypeId}")]
        public async Task<IActionResult> DeleteMeatType(Guid meatTypeId)
        {
            _logger.LogInformation("DeleteMeatType action method in MeatTypesController.");

            // Try to get meat type with id, null if failed
            MeatType? meatType = await _meatTypesService.GetMeatTypeByIdAsync(meatTypeId);

            // If meat type not found, return detailed 404 response
            if (meatType == null)
            {
                _logger.LogWarning($"Meat type not found, ID: {meatTypeId}");
                return Problem(
                    detail: $"Meat type not found, ID: {meatTypeId}",
                    statusCode: 404,
                    title: "Meat type search.");
            }

            // Try to delete meat type, null if failed
            MeatType? result = await _meatTypesService.DeleteMeatTypeAsync(meatType);

            // If deleting failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to delete meat type.");
                return Problem(
                    detail: "Failed to delete meat type.",
                    statusCode: 500,
                    title: "Deleting meat type.");
            }

            return Ok(result);
        }
    }
}
