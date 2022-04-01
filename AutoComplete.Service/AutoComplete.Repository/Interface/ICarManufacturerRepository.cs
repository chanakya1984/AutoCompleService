namespace AutoComplete.Repository.Interface;

using Entities;
public interface ICarManufacturerRepository
{
    IEnumerable<CarManufacturer> GetAllManufacturer( bool trackChanges );
    Task CreateManufacturer( CarManufacturer model );
    Task<CarManufacturer?> GetByIdAsync( int id, bool trackChanges );

    Task<IEnumerable<CarManufacturer>> FilterByNameStartsWith( string name );

}
