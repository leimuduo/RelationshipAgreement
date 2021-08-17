using AutoMapper;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Models.Entities;

namespace RelationshipApi.Helpers.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(target => target.ProductOptions, map =>
                    map.MapFrom(src => src.ProductOptions));
            CreateMap<ProductDto, Product>()
                .ForMember(target => target.ProductOptions, map =>
                    map.MapFrom(src => src.ProductOptions));
            CreateMap<ProductOption, ProductOptionDto>().ReverseMap();
        }
    }
}