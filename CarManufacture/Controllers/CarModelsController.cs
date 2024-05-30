using CarManufacture.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarManufacture.Controllers
{
    [ApiController]
    [Route("api/models")]
    public class CarModelsController : ControllerBase
    {
        [HttpGet]       
        public async Task<IActionResult> GetModelsForMakeAndYear([FromQuery] string make, [FromQuery] int modelyear)
        {
            CarModelService carModelService = new CarModelService();
            var models = await carModelService.GetAllCarModelsProduced(make.ToUpper(), modelyear);
            return Ok(new { models});
        }
    }
}