



namespace AutoComplete.Business.Implementation;

using AutoComplete.Common.DTO;
using AutoComplete.Repository.Entities;
using Interface;

using AutoComplete.Repository.Interface;
using AutoMapper;

public class CarManufacturerService : ICarManufacturerService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly Mapper _mapper;

    public CarManufacturerService( IRepositoryManager repositoryManager, Mapper mapper )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public CarManufacturerDto CreateOneCarManufacturer( int id, CarManufacturerDto carManufacturer )
    {
        var entity = _mapper.Map<CarManufacturer>( carManufacturer );
        _repositoryManager.CarManufacturer.CreateManufacturer( entity );
        return _mapper.Map<CarManufacturerDto>( entity );
    }

    public IEnumerable<CarManufacturerDto> GetAllCarManufacturer( bool loadRelations = false ) => _mapper.Map<CarManufacturerDto[]>( _repositoryManager.CarManufacturer.GetAllManufacturer( false ) );
}
