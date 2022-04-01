namespace AutoComplete.Business.Interface;

using Common.DTO;
public interface ICarManufacturerService
{
    Task<(string Id, CarManufacturerDto Manufacturer)> CreateOneCarManufacturer(CarManufacturerDto carManufacturer);
    IEnumerable<CarManufacturerDto> GetAllCarManufacturer( bool loadRelations = false );
    Task<CarManufacturerDto?> GetById(string id);
    Task<IEnumerable<CarManufacturerDto>> GetByName(string name);
}
