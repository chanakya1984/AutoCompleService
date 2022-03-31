namespace AutoComplete.Repository.Implementation;


using DbContext;
using Entities;
using Interface;
public class CarManufacturerRepository : RepositoryBase<CarManufacturer>, ICarManufacturerRepository
{
    public CarManufacturerRepository(CarAutoCompleteDbContext context) : base(context)
    {
    }
}
