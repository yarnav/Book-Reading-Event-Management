using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Company.Project.Web.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignupModel userModel);
        Task<SignInResult> PasswordSignInAsync(LoginModel signInModel);
        Task SignOutAsync();
    }
}