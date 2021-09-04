using Microsoft.AspNetCore.Mvc;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Controllers
{
    [Route("api/families")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public MembersController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
    }
}