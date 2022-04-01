

namespace AutoComplete.Repository.Interface;

using Entities;
public interface ICarManufacturerRepository
{
    IEnumerable<CarManufacturer> GetAllManufacturer( bool trackChanges );
    Task CreateManufacturer( CarManufacturer model );
}
