using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RelationshipApi.Models.Entities
{
    public class Member
    {
        [Key] public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid? FamilyId { get; set; }
        public virtual Family Family { get; set; }

        public virtual IEnumerable<Invitation> Invitations { get; set; }
        public virtual IEnumerable<Token> Tokens { get; set; }
    }
}