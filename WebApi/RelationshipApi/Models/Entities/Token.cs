using System;
using System.ComponentModel.DataAnnotations;

namespace RelationshipApi.Models.Entities
{
    public class Token
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Guid FamilyId { get; set; }
        public virtual Family Family { get; set; }

        public Guid MemberId { get; set; }
        public virtual Member Member { get; set; }

        public Guid? IssuerId { get; set; }
        public virtual Member Issuer { get; set; }
    }
}