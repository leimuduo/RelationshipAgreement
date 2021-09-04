using System;
using System.ComponentModel.DataAnnotations;

namespace RelationshipApi.Models.Entities
{
    public class User
    {
        [Key] public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string TimeZone { get; set; }
        public string PasswordHash { get; set; }
        public virtual Member Member { get; set; }
    }
}