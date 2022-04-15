namespace AutoComplete.Business.AutoMappers.Profiles;

using Common.DTO;
using Repository.Entities;

using AutoMapper;
public class AutoCompleteProfile : Profile
{
    public AutoCompleteProfile()
    {
       
        CreateMap<CarManufacturerDto, CarManufacturer>().DisableCtorValidation().ReverseMap();
        CreateMap<CarModelDto, CarModel>().DisableCtorValidation().ReverseMap();
    }
}

