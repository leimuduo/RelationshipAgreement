using System;
using System.Collections.Generic;

namespace RelationshipApi.Models.Dtos
{
    public class UserTokenDto
    {
        public Guid UserId { get; set; }
        public IEnumerable<TokenDto> Tokens { get; set; }
    }
}