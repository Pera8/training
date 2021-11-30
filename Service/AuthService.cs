using Microsoft.AspNetCore.Identity;
using Repository.Models;
using Shared.DTO;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly AuthTokenService authTokenService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, AuthTokenService authTokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authTokenService = authTokenService;
        }

        public async Task<User> RegisterUserAuth(RegisterUser registerUser)
        {
            var _user = await userManager.FindByEmailAsync(registerUser.Email);
            if (_user != null)
            {
                throw new Exception("user exsist");
            }
            var user = new User
            {
                 
                UserName = registerUser.Name,
                Name = registerUser.Name,
                Email = registerUser.Email,
                LastName = registerUser.LastName
            };

            var result = await userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException();
            }
            return user;
        }

        public async Task<AuthDTO> LoginUserAuth(LoginUser loginParam)
        {
            if (loginParam == null)
                throw new UnauthorizedAccessException();
            var auth = await authTokenService.Authenticate(loginParam.Email, loginParam.Password, loginParam.RememberMe);
            // auth.Wait();
            if (auth == null)
            {
                throw new ArgumentException("Email or password are incorrect");
            }
            return auth;
        }
    }
}
