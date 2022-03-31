namespace AutoComplete.Repository.Implementation;


using DbContext;
using Entities;
using Interface;
public class CarManufacturerRepository : RepositoryBase<CarManufacturer>, ICarManufacturerRepository
{
    public CarManufacturerRepository(CarAutoCompleteDbContext context) : base(context)
    {
    }

    public IEnumerable<CarManufacturer> GetAllManufacturer( bool trackChanges ) => FindAll( trackChanges );
    public void CreateManufacturer( CarManufacturer model ) => Create( model );
}
