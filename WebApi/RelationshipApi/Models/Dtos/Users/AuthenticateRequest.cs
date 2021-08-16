using System.ComponentModel.DataAnnotations;

namespace RelationshipApi.Models.Dtos.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}