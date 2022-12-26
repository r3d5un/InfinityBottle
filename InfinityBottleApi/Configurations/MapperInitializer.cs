using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;

namespace InfinityBottleApi.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<Brand, BrandDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<History, HistoryDto>().ReverseMap();
        CreateMap<InfinityBottle, InfinityBottleDto>().ReverseMap();
        CreateMap<Whisky, WhiskyDto>().ReverseMap();
    }
}
