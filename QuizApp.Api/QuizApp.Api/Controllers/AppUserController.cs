using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;
using QuizApp.Api.Service;

namespace QuizApp.Api.Controllers
{
    [ApiController]
    [Route("AppUser")]
    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _appUserService;
        public AppUserController(AppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public async Task<ActionResult<AppUserDto>> GetAppUserAsync(string userId)
        {
            AppUser? user = await _appUserService.GetAppUserAsync(userId);

            if(user is not null)
            {
                return new AppUserDto(user);
            }
            return BadRequest("Failed to find using str userId");
        }
    }
}
