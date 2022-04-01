namespace AutoComplete.Repository.Implementation;

using DbContext;
using Entities;
using Interface;

public class CarModelRepository : RepositoryBase<CarModel>, ICarModelRepository
{
    public CarModelRepository(CarAutoCompleteDbContext context) : base(context)
    {
    }
}
