using System.Text.Json.Serialization;

namespace RelationshipApi.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore] public string PasswordHash { get; set; }
    }
}