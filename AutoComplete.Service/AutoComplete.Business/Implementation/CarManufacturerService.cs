



namespace AutoComplete.Business.Implementation;

using AutoComplete.Common.DTO;
using AutoComplete.Repository.Entities;
using Interface;

using AutoComplete.Repository.Interface;
using AutoMapper;

public class CarManufacturerService : ICarManufacturerService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public CarManufacturerService( IRepositoryManager repositoryManager, IMapper mapper )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<(int, CarManufacturerDto)> CreateOneCarManufacturer( CarManufacturerDto carManufacturer )
    {
        var entity = _mapper.Map<CarManufacturer>( carManufacturer );
        await _repositoryManager.CarManufacturer.CreateManufacturer( entity );
        await _repositoryManager.Save();
        return (entity.Id, _mapper.Map<CarManufacturerDto>( entity ));
    }

    public IEnumerable<CarManufacturerDto> GetAllCarManufacturer( bool loadRelations = false ) => _mapper.Map<CarManufacturerDto[]>( _repositoryManager.CarManufacturer.GetAllManufacturer( false ) );

    public async Task<CarManufacturerDto> GetById( int id )
    {
        var value = await _repositoryManager.CarManufacturer.GetByIdAsync( id, false );
        return _mapper.Map<CarManufacturerDto>( value );
    }

    public async Task<IEnumerable<CarManufacturerDto>> GetByName( string name )
    {
        var result = await _repositoryManager.CarManufacturer.FilterByNameStartsWith( name );
        return _mapper.Map<IEnumerable<CarManufacturerDto>>( result );
    }
}
