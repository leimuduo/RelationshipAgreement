using System;
using RelationshipApi.Models.Entities;

namespace RelationshipApi.Models.Dtos
{
    public class MemberDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}