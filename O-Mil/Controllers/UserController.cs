using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O_Mil.Controllers
{
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly AuthTokenService authTokenService;
        private readonly AuthService _authService;

        public UserController(AuthTokenService authTokenService, AuthService authService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.authTokenService = authTokenService;
            _authService = authService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            var result = await _authService.RegisterUserAuth(registerUser);
            return Ok(result);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginUser loginParam)
        {
            var result = await _authService.LoginUserAuth(loginParam);
            return Ok(result);
        }
    }
}
