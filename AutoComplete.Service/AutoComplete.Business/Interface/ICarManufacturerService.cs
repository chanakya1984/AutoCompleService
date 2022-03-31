namespace AutoComplete.Business.Interface;

using Common.DTO;
public interface ICarManufacturerService
{
    CarManufacturerDto CreateOneCarManufacturer(int id, CarManufacturerDto carManufacturer);

    IEnumerable<CarManufacturerDto> GetAllCarManufacturer( bool loadRelations = false );

}
