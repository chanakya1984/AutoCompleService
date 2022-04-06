

namespace AutoComplete.Api.Controllers;

using Business.Interface;
using Common.DTO;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route( "[controller]/V1" )]
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
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateNew( CarManufacturerDto data )
    {
        _logger.LogWarning( "In function create new" );
        var obj = await _manufacturerService.CreateOneCarManufacturer( data );
        _logger.LogWarning( "created new {id}",obj.Id );
        return CreatedAtRoute( "GetById/{id}", new {id = obj.Id}, obj );
    
    }

    [HttpGet("GetById/{id}",Name = "GetById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarManufacturerDto))]
    [ProducesResponseType( StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById( string id )
    {
        var result = await _manufacturerService.GetById( id );
        if (result is null)
        {
            return NotFound( "Invalid Id." );
        }
        return Ok(result);
    }

    [ProducesResponseType( StatusCodes.Status200OK, Type = typeof( IEnumerable<CarManufacturerDto> ) )]
    [ProducesResponseType( StatusCodes.Status404NotFound )]
    [HttpGet( "SearchByNameStartsWith/{name}" )]
    public async Task<IActionResult> SearchByName( string name )
    {
        var result = await _manufacturerService.GetByName( name );
        if (result.Any())
        {
            return Ok( result );
        }

        return NotFound( "Invalid Name." );
    }
}

