using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;
using QuizApp.Api.Identity;
using QuizApp.Api.Service;
using System.Security.Claims;

namespace QuizApp.Api.Controllers
{
    [ApiController]
    [Route("AppUser")]
    [Authorize]
    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _appUserService;
        public AppUserController(AppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public async Task<ActionResult<AppUserDto>> GetAppUserAsync(string userName)
        {
            AppUser? user = await _appUserService.GetAppUserAsync(userName);

            if(user is not null)
            {
                return new AppUserDto(user);
            }
            return BadRequest("Failed to find using str userName");
        }

        [HttpGet("self")]
        public async Task<ActionResult<AppUserDto>> GetAppUserAsync()
        {
            var userId = HttpContext.User.FindFirstValue(Claims.UserId);
            if (userId is not null)
            {

                AppUser? user = await _appUserService.GetAppUserIdAsync(userId);

                if (user is not null)
                {
                    return new AppUserDto(user);
                }
            }
            return BadRequest("Failed to find using str userId");
        }
    }
}
