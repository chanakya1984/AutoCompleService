

namespace AutoComplete.Repository.Interface;

using Entities;
public interface ICarManufacturerRepository
{
    IEnumerable<CarManufacturer> GetAllManufacturer( bool trackChanges );
    void CreateManufacturer( CarManufacturer model );
}
