using System;

namespace RelationshipApi.Models.Dtos
{
    public class TokenDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Guid MemberId { get; set; }
        public string MemberDisplayName { get; set; }

        public Guid IssuerId { get; set; }
        public string IssuerDisplayName { get; set; }
    }
}