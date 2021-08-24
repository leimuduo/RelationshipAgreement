using AutoMapper;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Models.Dtos.Users;
using RelationshipApi.Models.Entities;

namespace RelationshipApi.Helpers.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
            
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