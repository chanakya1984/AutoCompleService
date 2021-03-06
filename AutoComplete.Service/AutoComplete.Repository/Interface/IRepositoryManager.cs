namespace AutoComplete.Repository.Interface;
public interface IRepositoryManager
{
    ICarManufacturerRepository CarManufacturer { get; }
    ICarModelRepository CarModel { get; }
    Task Save();
}
