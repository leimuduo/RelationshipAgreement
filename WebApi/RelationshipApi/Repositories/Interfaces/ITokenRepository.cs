using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;

namespace RelationshipApi.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        Task<TokenDto> GetTokenById(Guid id);
        Task<IEnumerable<TokenDto>> GetTokensByMemberId(Guid memberId);
        Task<TokenDto> CreateToken(TokenDto token);
        Task<TokenDto> UpdateToken(TokenDto token);
        Task<bool> DeleteToken(Guid id);
    }
}