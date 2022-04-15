namespace AutoComplete.Common.DTO;
using Enums;

public record class CarModelDto(int ManufactureId, string Name, CarFuelTypes FuelType,
    string EngineCapacity);
    
