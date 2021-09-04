using System;

namespace RelationshipApi.Models.Dtos
{
    public class MemberDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
    }
}