using System;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;

namespace RelationshipApi.Services.Interfaces
{
    public interface IFamilyService
    {
        Task<FamilyDto> GetFamilyByUserId(Guid userId);
    }
}