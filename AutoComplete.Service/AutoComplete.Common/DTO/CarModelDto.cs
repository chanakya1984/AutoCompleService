namespace AutoComplete.Common.DTO;
using Enums;

public record class CarModelDto(Guid ManufactureId, string ModelName, CarFuelTypes FuelType,
    string EngineCapacity);
    
