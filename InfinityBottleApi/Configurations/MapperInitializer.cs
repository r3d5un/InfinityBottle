using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;

namespace InfinityBottleApi.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<Brand, BrandDto>().ReverseMap();
        CreateMap<Brand, BrandGetDto>().ReverseMap();
        CreateMap<Brand, BrandPostDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryPostDto>().ReverseMap();
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Company, CompanyGetDto>().ReverseMap();
        CreateMap<Company, CompanyPostDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<History, HistoryDto>().ReverseMap();
        CreateMap<InfinityBottle, InfinityBottleDto>().ReverseMap();
        CreateMap<Whisky, WhiskyDto>().ReverseMap();
    }
}
