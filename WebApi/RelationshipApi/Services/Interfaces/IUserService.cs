using System.Collections.Generic;
using RelationshipApi.Models.Dtos.Users;
using RelationshipApi.Models.Entities;

namespace RelationshipApi.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}