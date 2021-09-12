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
                        switch (prop)
                        {
                            // ignore null & empty string properties
                            case null:
                            case string arg3 when string.IsNullOrEmpty(arg3):
                                return false;
                            default:
                                return true;
                        }
                    }
                ));

            CreateMap<Product, ProductDto>()
                .ForMember(target => target.ProductOptions, map =>
                    map.MapFrom(src => src.ProductOptions));
            CreateMap<ProductDto, Product>()
                .ForMember(target => target.ProductOptions, map =>
                    map.MapFrom(src => src.ProductOptions));
            CreateMap<ProductOption, ProductOptionDto>().ReverseMap();

            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();
            CreateMap<Token, TokenDto>();
            CreateMap<TokenDto, Token>();
            
        }
    }
}