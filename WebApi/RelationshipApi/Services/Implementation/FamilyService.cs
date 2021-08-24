using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Services.Implementation
{
    public class FamilyService : IFamilyService
    {
        public async Task<FamilyDto> GetFamilyByUserId(Guid userId)
        {
            return new FamilyDto
            {
                Id = Guid.NewGuid(),
                Name = "相亲相爱一家人",
                Members = new List<MemberDto>
                {
                    new()
                    {
                        UserId = userId,
                        UserName = "贾铭梓"
                    },
                    new()
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "甄梅劲"
                    }
                }
            };
        }
    }
}