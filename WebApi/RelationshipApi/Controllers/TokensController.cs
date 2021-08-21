using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Services.Interfaces;


namespace RelationshipApi.Controllers
{
    [Route("api/tokens")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokensController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserTokenDto>> GetFamilyByUser(Guid userId)
        {
            if (!GeneralGuidCheck(userId)) return BadRequest($"invalid user Id {userId}");

            var family = await _tokenService.GetTokenByUserId(userId);
            if (family == null)
                return NotFound("Family not found");

            return Ok(family);
        }

        // todo: move this following into extension or slice function. 
        private static bool GeneralGuidCheck(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}