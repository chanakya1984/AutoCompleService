namespace AutoComplete.Business.Implementation;

using Common.DTO;
using Repository.Entities;
using Interface;
using Repository.Interface;

using SerilogTimings;
using Microsoft.Extensions.Logging;
using AutoMapper;
using HashidsNet;

public class CarManufacturerService : ICarManufacturerService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly IHashids _hashId;
    private readonly ILogger<CarManufacturerService> _logger;
    public CarManufacturerService( IRepositoryManager repositoryManager, IMapper mapper, IHashids hashid, ILogger<CarManufacturerService> logger )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _hashId = hashid;
        _logger = logger;
    }

    public async Task<(string, CarManufacturerDto)> CreateOneCarManufacturer( CarManufacturerDto carManufacturer )
    {
        var entity = _mapper.Map<CarManufacturer>( carManufacturer );
        using (Operation.Time( "Business.CarManufacturerService.CreateOneCarManufacturer.DatabaseTime" ))
        {
            await _repositoryManager.CarManufacturer.CreateManufacturer( entity );
            await _repositoryManager.Save();
        }

        return (_hashId.Encode( entity.Id), _mapper.Map<CarManufacturerDto>( entity ));
    }

    public IEnumerable<CarManufacturerDto> GetAllCarManufacturer( bool loadRelations = false )
    {
        using (Operation.Time( "Business.CarManufacturerService.GetAllCarManufacturer.DatabaseTime" ))
        {
            return _mapper.Map<CarManufacturerDto[]>( _repositoryManager.CarManufacturer.GetAllManufacturer( false ) );
        }
    }

    public async Task<CarManufacturerDto?> GetById( string id )
    {
        var decodedId = _hashId.Decode( id );
        if (decodedId.Length < 1)
        {
            return null;
        }

        CarManufacturer? value;
        using (Operation.Time( "Business.CarManufacturerService.GetById.DatabaseTime" ))
        {
            value = await _repositoryManager.CarManufacturer.GetByIdAsync( decodedId[0], false );
        }

        return _mapper.Map<CarManufacturerDto>( value );
    }

    public async Task<IEnumerable<CarManufacturerDto>> GetByName( string name )
    {
        IEnumerable<CarManufacturer> result;
        using (Operation.Time( "Business.CarManufacturerService.GetByName.DatabaseTime" ))
        {
            result = await _repositoryManager.CarManufacturer.FilterByNameStartsWith( name );
        }

        return _mapper.Map<IEnumerable<CarManufacturerDto>>( result );
    }
}
