namespace AutoComplete.Api.Controllers;

using Business.Interface;
using Common.DTO;

using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

[ApiController]
// [Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]

public class CarModelController : ControllerBase
{
    private readonly ILogger<CarManufactureController> _logger;
    private readonly ICarModelService _carModelService;

    public CarModelController(ILogger<CarManufactureController> logger, ICarModelService manufacturerService)
    {
        _logger = logger;
        _carModelService = manufacturerService;
    }

    [HttpPost("CreateOne")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateNew(CarModelDto data)
    {
        (string Id, CarModelDto carModel) createdData;
        using (Operation.Time("Creating New Manufacture"))
        {
            createdData = await _carModelService.CreateOneCarModel(data);
        }
        return CreatedAtRoute("GetCarModelById/{id}", new { id = createdData.Id }, createdData.carModel);

    }

    [HttpGet("GetCarModelById/{id}", Name = "GetCarModelById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarManufacturerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var result =  await _carModelService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetAllCarModel")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CarManufacturerDto>))]
    public async Task<IActionResult> GetAllCarModels() => Ok(_carModelService.GetAllCarModel(false));
}
