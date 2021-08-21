using System;
using System.Collections.Generic;

namespace RelationshipApi.Models.Dtos
{
    public class FamilyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<MemberDto> Members { get; set; }
    }
}