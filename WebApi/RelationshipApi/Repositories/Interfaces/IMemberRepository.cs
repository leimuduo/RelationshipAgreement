using System;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;

namespace RelationshipApi.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<MemberDto> GetMemberById(Guid id);
        Task<MemberDto> CreateMember(MemberDto newMember);
        Task<MemberDto> UpdateMember(MemberDto member);
        Task<bool> DeleteMember(Guid id);
    }
}