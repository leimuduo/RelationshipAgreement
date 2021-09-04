using System;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;

namespace RelationshipApi.Services.Interfaces
{
    public interface ITokenService
    {
        Task<UserTokenDto> GetTokenByUserId(Guid userId);
    }
}