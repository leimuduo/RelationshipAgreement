using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelationshipApi.Models.Entities
{
    public class Family
    {
        [Key] public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Member> Members { get; set; }


        public virtual IEnumerable<Invitation> Invitations { get; set; }
    }
}