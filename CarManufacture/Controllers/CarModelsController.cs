
using CarManufacture.Services;
using Microsoft.AspNetCore.Mvc;
namespace CarManufacture.Controllers
{

    [ApiController]
    [Route("api/models")]
    public class CarModelsController : ControllerBase
    {
        [HttpGet]
        public  IActionResult GetModelsForMakeAndYear([FromQuery] string make, [FromQuery] int modelyear)
        {
            CarModelService carModelService = new CarModelService();           
            var Models =  carModelService.GetAllCarModelsProduced(make.ToUpper(), modelyear);
            return Ok(new { Models });
        }
    }
}