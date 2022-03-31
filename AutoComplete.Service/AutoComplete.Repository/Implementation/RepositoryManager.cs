﻿

using AutoComplete.Repository.DbContext;

namespace AutoComplete.Repository.Implementation;
using Interface;
public class RepositoryManager : IRepositoryManager
{

    private readonly CarAutoCompleteDbContext _context;
    private readonly Lazy<ICarManufacturerRepository> _carManufacturerRepository;
    private readonly Lazy<ICarModelRepository> _carModelRepository;

    public RepositoryManager( CarAutoCompleteDbContext context)
    {
        _context = context;
        _carManufacturerRepository =
            new Lazy<ICarManufacturerRepository>( () => new CarManufacturerRepository( context ) );
        _carModelRepository = new Lazy<ICarModelRepository>( () => new CarModelRepository( context ) );
    }

    public ICarManufacturerRepository CarManufacturer => _carManufacturerRepository.Value;
    public ICarModelRepository CarModel => _carModelRepository.Value;
    public async void Save() => await  _context.SaveChangesAsync();
}
