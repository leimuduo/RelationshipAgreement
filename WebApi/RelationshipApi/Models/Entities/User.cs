using System;
using System.Text.Json.Serialization;

namespace RelationshipApi.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public string TimeZone { get; set; }

        [JsonIgnore] public string PasswordHash { get; set; }
        public virtual Member Member { get; set; }
    }
}