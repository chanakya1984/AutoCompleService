

namespace AutoComplete.Api.Controllers;

using Business.Interface;
using Common.DTO;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route( "[controller]" )]
public class CarManufactureController : ControllerBase
{
    private readonly ILogger<CarManufactureController> _logger;
    private readonly ICarManufacturerService _manufacturerService;

    public CarManufactureController( ILogger<CarManufactureController> logger,
        ICarManufacturerService manufacturerService )
    {
        _logger = logger;
        _manufacturerService = manufacturerService;
    }

    [HttpPost( Name = "CreateNew" )]
    public async Task<IActionResult> CreateNew( CarManufacturerDto data )
    {
        var obj = await _manufacturerService.CreateOneCarManufacturer( data );
        return CreatedAtRoute( "GetById/{id}", new {id = obj.Id}, obj );
    }

    [HttpGet( Name = "GetById/{id}" )]
    public async Task<IActionResult> GetById( int id )
    {
        var result = _manufacturerService.GetAllCarManufacturer( false );
        return Ok(result.Take( 1 ));
    }
}

