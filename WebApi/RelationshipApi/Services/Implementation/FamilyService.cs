using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Repositories.Interfaces;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Services.Implementation
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _repo;

        public FamilyService(IFamilyRepository repo)
        {
            _repo = repo;
        }

        public async Task<FamilyDto> GetFamilyByUserId(Guid userId, bool includeToken = false)
        {
            var family = new FamilyDto
            {
                Id = Guid.NewGuid(),
                Name = "相亲相爱一家人",
                Members = new List<MemberDto>
                {
                    new()
                    {
                        UserId = userId,
                        UserName = "贾铭梓",
                        DisplayName = "贾铭梓"
                    },
                    new()
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "甄梅劲",
                        DisplayName = "甄梅劲"
                    }
                }
            };

            if (includeToken) family.Tokens = new List<TokenDto>();

            return family;
        }
    }
}