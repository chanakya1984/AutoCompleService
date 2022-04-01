

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

    [HttpPost("CreateOne" )]
    public async Task<IActionResult> CreateNew( CarManufacturerDto data )
    {
        var obj = await _manufacturerService.CreateOneCarManufacturer( data );
        return CreatedAtRoute( "GetById/{id}", new {id = obj.Id}, obj );
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById( int id )
    {
        var result = await _manufacturerService.GetById( id );
        return Ok(result);
    }

    //[Route( "SearchByName/{name}" )]
    [HttpGet( "SearchByName/{name}" )]
    public async Task<IActionResult> SearchByName( string name )
    {
        var result = await _manufacturerService.GetByName( name );
        return Ok( result );
    }
}

