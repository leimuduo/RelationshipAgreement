using System;
using System.ComponentModel.DataAnnotations;

namespace RelationshipApi.Models.Entities
{
    public class Invitation
    {
        [Key] public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UsedDateTime { get; set; }
        public bool Used { get; set; }

        public Guid MemberId { get; set; }
        public virtual Member Invitor { get; set; }

        public Guid FamilyId { get; set; }
        public virtual Family Family { get; set; }
    }
}