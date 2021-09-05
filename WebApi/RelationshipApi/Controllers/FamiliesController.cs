using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Controllers
{
    [Route("api/families")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        private readonly IUserService _userService;

        public FamiliesController(IFamilyService familyService, IUserService userService)
        {
            _familyService = familyService;
            _userService = userService;
        }

        [HttpGet("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FamilyDto>> GetFamilyByUser(Guid userId, bool includeToken)
        {
            if (!GeneralGuidCheck(userId)) return BadRequest($"invalid user Id {userId}");
            // if (_userService.GetById(userId) == null)
            //     return BadRequest("User can not be found.");


            var family = await _familyService.GetFamilyByUserId(userId, includeToken);

            if (family == null)
                return NotFound("Family not found");

            return Ok(family);
        }

        private static bool GeneralGuidCheck(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}