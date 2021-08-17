using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Helpers.Auth
{
    public class JwtMiddleware
    {
        private readonly AppSettings _appSettings;
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId.Value);

            await _next(context);
        }
    }
}