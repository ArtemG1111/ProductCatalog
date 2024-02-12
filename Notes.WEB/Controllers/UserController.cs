using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger _logger;
        public UserController(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager
        ,ILogger logger)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> SingUp(UserViewModel modelUser)
        {
            if (ModelState.IsValid)
            {  
                var identityUser = _mapper.Map<IdentityUser>(modelUser);
                var result = await _userManager.CreateAsync(identityUser, modelUser.Password);
                if (!result.Succeeded)
                {
                    return BadRequest("Error! User was not creating");
                }
                await _signInManager.SignInAsync(identityUser, false);
            }
            return Ok("User create");   
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SingIn(UserViewModel modelUser)
        {
            if (ModelState.IsValid)
            {
                var findUser = await _userManager.FindByNameAsync(modelUser.UserName);
                if (findUser == null)
                {
                    return BadRequest("User Not Found!");
                }
                await _signInManager.PasswordSignInAsync(findUser, modelUser.Password, false, false);
            }

            return Ok("Succecfully signed in");
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> SignOut(UserViewModel modelUser)
        {
            if (User.Identity?.Name == null)
            {
                return BadRequest("You need to sign in first");
            }
            await _signInManager.SignOutAsync();

            return Ok("Succecfullu signed out");
        }
    }
}
