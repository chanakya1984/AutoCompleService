namespace AutoComplete.Repository.Interface;

using Entities;

public interface ICarModelRepository
{
    Task CreateCarModelAsync(CarModel carModel);
    IEnumerable<CarModel> GetAllCarModels();
    IEnumerable<CarModel> GetAllCarModelByManufacture(int manufactureId);
    IEnumerable<CarModel> GetAllCarModelByName(string name);
    Task<CarModel?> GetCarModelByIdAsync(int id);
    void UpdateCarModel(CarModel model);
}
