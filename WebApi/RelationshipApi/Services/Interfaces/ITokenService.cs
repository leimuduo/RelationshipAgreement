using System;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;

namespace RelationshipApi.Services.Interfaces
{
    public interface ITokenService
    {
        Task<UserTokenDto> GetTokenByMemberId(Guid memberId);
        Task<TokenDto> GetTokenById(Guid id);
        Task<TokenDto> UpdateToken(TokenDto token);
        Task<TokenDto> CreateToken(TokenDto token);
        Task<bool> DeleteToken(Guid id);
    }
}