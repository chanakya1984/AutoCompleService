

using AutoComplete.Repository.DbContext;

namespace AutoComplete.Repository.Implementation;
using Interface;
public class RepositoryManager : IRepositoryManager
{

    private readonly CarAutoCompleteDbContext _context;
    private readonly Lazy<ICarManufacturerRepository> _carManufacturerRepository;
    private readonly Lazy<ICarModelRepository> _carModelRepository;

    public RepositoryManager( CarAutoCompleteDbContext context, Lazy<ICarManufacturerRepository> carManufacturerRepository, Lazy<ICarModelRepository> carModelRepository )
    {
        _context = context;
        _carManufacturerRepository = carManufacturerRepository;
        _carModelRepository = carModelRepository;
    }

    public ICarManufacturerRepository CarManufacturer => _carManufacturerRepository.Value;
    public ICarModelRepository CarModel => _carModelRepository.Value;
    public async void Save() => await  _context.SaveChangesAsync();
}
