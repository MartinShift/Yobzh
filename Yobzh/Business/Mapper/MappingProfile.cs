using AutoMapper;
using Yobzh.Business.Models;
using Yobzh.Data.Entities;

namespace Yobzh.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>();
        CreateMap<Product, Piska>()
        .ForMember(x => x.Artem, x => x.MapFrom(x => x.Name))
        .ForMember(x=> x.Length, x => x.MapFrom(x=> x.Id));
    }
}
