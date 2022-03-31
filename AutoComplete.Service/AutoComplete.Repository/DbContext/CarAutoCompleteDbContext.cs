

namespace AutoComplete.Repository.DbContext;
using Entities;

using Microsoft.EntityFrameworkCore;

public class CarAutoCompleteDbContext : DbContext
{
    public DbSet<CarManufacturer> CarManufacturers { get; set; }
    public DbSet<CarModel> CarModels { get; set; }

    public CarAutoCompleteDbContext()
    {

    }

}
