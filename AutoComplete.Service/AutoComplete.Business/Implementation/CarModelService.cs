namespace AutoComplete.Business.Implementation;

using Interface;
using Common.DTO;
using Repository.Interface;

using AutoMapper;
using HashidsNet;
using Microsoft.Extensions.Logging;
using Repository.Entities;
using SerilogTimings;

internal class CarModelService : ICarModelService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly IHashids _hashId;
    private readonly ILogger<CarModelService> _logger;

    public CarModelService(IRepositoryManager repositoryManager, IMapper mapper, IHashids hashId, ILogger<CarModelService> logger)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _hashId = hashId;
        _logger = logger;
    }

    public async Task<(string Id, CarModelDto carModel)> CreateOneCarModel(CarModelDto carModel)
    {
        var entity = _mapper.Map<CarModel>(carModel);
        
        using (Operation.Time(""))
        {
            await _repositoryManager.CarModel.CreateCarModelAsync(entity);
            await _repositoryManager.Save();
        }
        return (_hashId.Encode(entity.Id), _mapper.Map<CarModelDto>(entity));
    }

    public IEnumerable<CarModelDto> GetAllCarModel(bool loadRelations = false)
    {
        using (Operation.Time(""))
        {
            return _mapper.Map<CarModelDto[]>(_repositoryManager.CarModel.GetAllCarModels());
        }
    }

    public async Task<CarModelDto?> GetByIdAsync(string id)
    {
        var decodedId = _hashId.Decode(id);
        using (Operation.Time(""))
        {
            return _mapper.Map<CarModelDto>(await _repositoryManager.CarModel.GetCarModelByIdAsync(decodedId[0]));
        }
    }

    public Task<IEnumerable<CarModelDto>> GetByNameAsync(string name) => throw new NotImplementedException();
}
