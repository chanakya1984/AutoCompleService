namespace AutoComplete.Repository.Entities;

public class CarManufacturer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}

