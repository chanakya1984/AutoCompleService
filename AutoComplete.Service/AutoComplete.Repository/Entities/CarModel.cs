namespace AutoComplete.Repository.Entities;
using Common.Enums;

public class CarModel
{
    public int Id { get; set; }
    public int ManufactureId { get; set; }
    public CarManufacturer Manufacturer { get; set; } = new CarManufacturer();
    public string Name { get; set; } = string.Empty;
    public CarFuelTypes FuelType { get; set; }
    public string EngineCapacity { get; set; } = string.Empty;
}
