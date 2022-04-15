namespace AutoComplete.Repository.Implementation;

using DbContext;
using Entities;
using Interface;
using Microsoft.EntityFrameworkCore;

public class CarModelRepository : RepositoryBase<CarModel>, ICarModelRepository
{
    public CarModelRepository(CarAutoCompleteDbContext context) : base(context)
    {
    }

    public async Task CreateCarModelAsync(CarModel carModel) => await Create(carModel);

    public IEnumerable<CarModel> GetAllCarModels() => FindAll(false);

    public IEnumerable<CarModel> GetAllCarModelByManufacture(int manufactureId) =>
        FindByCondition(z => z.Id == manufactureId, false);

    public IEnumerable<CarModel> GetAllCarModelByName(string name) =>
        FindByCondition(x => x.Name.StartsWith(name), false);

    public async Task<CarModel?> GetCarModelByIdAsync(int id) => await FindByCondition(x => x.Id == id,false).FirstOrDefaultAsync();


    public void UpdateCarModel(CarModel model) => Update(model);
}
