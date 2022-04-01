using Microsoft.EntityFrameworkCore;

namespace AutoComplete.Repository.Implementation;


using DbContext;
using Entities;
using Interface;

public class CarManufacturerRepository : RepositoryBase<CarManufacturer>, ICarManufacturerRepository
{
    public CarManufacturerRepository( CarAutoCompleteDbContext context ) : base( context )
    {
    }

    public IEnumerable<CarManufacturer> GetAllManufacturer( bool trackChanges ) => FindAll( trackChanges );

    public async Task CreateManufacturer( CarManufacturer model ) => await Create( model );

    public async Task<CarManufacturer> GetByIdAsync( int id, bool trackChanges ) =>
        await FindByCondition( x => x.Id == id, trackChanges )
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<CarManufacturer>> FilterByNameStartsWith( string name ) =>
        await FindByCondition( x => x.Name.StartsWith( name ), false )
            .Select( k => new CarManufacturer() {Name = k.Name, Id = k.Id} ).ToListAsync();
}
