using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelationshipApi.Models.Entities
{
    public class Member
    {
        [Key] 
        public Guid UserId { get; set; }
        
        public User UserDto { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }

        public Guid? FamilyId { get; set; }
        public virtual Family Family { get; set; }

        public virtual IEnumerable<Invitation> Invitations { get; set; }
        public virtual IEnumerable<Token> Tokens { get; set; }
    }
}