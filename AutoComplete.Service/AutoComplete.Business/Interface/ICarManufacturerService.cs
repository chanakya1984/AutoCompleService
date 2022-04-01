namespace AutoComplete.Business.Interface;

using Common.DTO;
public interface ICarManufacturerService
{
    Task<(int Id, CarManufacturerDto Manufacturer)> CreateOneCarManufacturer(CarManufacturerDto carManufacturer);

    IEnumerable<CarManufacturerDto> GetAllCarManufacturer( bool loadRelations = false );

}
