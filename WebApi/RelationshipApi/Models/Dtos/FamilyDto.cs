using System;
using System.Collections.Generic;

namespace RelationshipApi.Models.Dtos
{
    public class FamilyDto
    {
        public Guid Id { get; set; } // Family ID
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MemberDto> Members { get; set; }

        public List<TokenDto> Tokens { get; set; }
    }
}