using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.API.CustomActionFilter;
using WebApiCRUD.API.Domain.DTO.Auth;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _token;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository token)
        {
            _userManager = userManager;
            _token = token;
        }

        [HttpPost]
        [Route("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody]RegisterDTO request)
        {
            var identityUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.UserName,
            };

            var identityResult = await _userManager.CreateAsync(identityUser, request.Password);

            if(identityResult.Succeeded)
            {
                if(request.Roles != null && request.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, request.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody]LoginDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);
            if (user != null)
            {
                var chekPasswordResult = await _userManager.CheckPasswordAsync(user, request.Password);
                if (chekPasswordResult)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwtToken = _token.CreateJWTToken(user, roles.ToList());
                        var respons = new LoginResposeDTO
                        {
                            JtwToken = jwtToken
                        };
                        return Ok(respons);
                    }
                }
            }
            return BadRequest("UserName or Password incorrect.");
        }
    }
}
