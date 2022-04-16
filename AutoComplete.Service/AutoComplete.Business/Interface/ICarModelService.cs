namespace AutoComplete.Business.Interface;

using Common.DTO;

public interface ICarModelService
{
    Task<(string Id, CarModelDto carModel)> CreateOneCarModel(CarModelDto carModel);
    IEnumerable<CarModelDto> GetAllCarModel(bool loadRelations = false);
    Task<CarModelDto?> GetByIdAsync(string id);
    Task<IEnumerable<CarModelDto>> GetByNameAsync(string name);
}
