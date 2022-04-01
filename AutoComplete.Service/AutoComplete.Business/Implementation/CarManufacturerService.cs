





namespace AutoComplete.Business.Implementation;

using AutoComplete.Common.DTO;
using AutoComplete.Repository.Entities;
using Interface;

using AutoComplete.Repository.Interface;
using AutoMapper;
using HashidsNet;

public class CarManufacturerService : ICarManufacturerService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly IHashids _hashId;

    public CarManufacturerService( IRepositoryManager repositoryManager, IMapper mapper, IHashids hashid )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _hashId = hashid;
    }

    public async Task<(string, CarManufacturerDto)> CreateOneCarManufacturer( CarManufacturerDto carManufacturer )
    {
        var entity = _mapper.Map<CarManufacturer>( carManufacturer );
        await _repositoryManager.CarManufacturer.CreateManufacturer( entity );
        await _repositoryManager.Save();
        return (_hashId.Encode( entity.Id), _mapper.Map<CarManufacturerDto>( entity ));
    }

    public IEnumerable<CarManufacturerDto> GetAllCarManufacturer( bool loadRelations = false ) => _mapper.Map<CarManufacturerDto[]>( _repositoryManager.CarManufacturer.GetAllManufacturer( false ) );

    public async Task<CarManufacturerDto?> GetById( string id )
    {
        var decodedId = _hashId.Decode( id );
        if (decodedId.Length < 1)
        {
            return null;
        }
        var value = await _repositoryManager.CarManufacturer.GetByIdAsync( decodedId[0], false );
        return _mapper.Map<CarManufacturerDto>( value );
    }

    public async Task<IEnumerable<CarManufacturerDto>> GetByName( string name )
    {
        var result = await _repositoryManager.CarManufacturer.FilterByNameStartsWith( name );
        return _mapper.Map<IEnumerable<CarManufacturerDto>>( result );
    }
}
