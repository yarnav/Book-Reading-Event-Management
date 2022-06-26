using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Company.Project.Web.Repository
{
    public class AccountRepository : IAccountRepository                 //Methods related to Account Signup and Login
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> CreateUserAsync(SignupModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.email,
                UserName = userModel.userName
            };
            var result = await _userManager.CreateAsync(user, userModel.password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(LoginModel signInModel)
        {
            return await _signInManager.PasswordSignInAsync(signInModel.userName, signInModel.password, signInModel.rememberMe, false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

