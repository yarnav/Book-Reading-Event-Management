using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Company.Project.Web.Models;
using Company.Project.Web.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Company.Project.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [Route("Signup")]        
        public async Task<IActionResult> Signup(SignupModel userModel)
        {
            if (ModelState.IsValid)                                                 //if modelstate is valid and signup is success then redirect to login page
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }
                else 
                { 
                    ModelState.Clear();
                    return RedirectToAction("login", "Account");
                }
                
            }
            return View(userModel);
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [Route("login")]        
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)                                                     //if modelstate is valid and login is success then redirect to home page
            {
                var result = await _accountRepository.PasswordSignInAsync(loginModel);
                if (result.Succeeded)
                {   
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                    return View(loginModel);
                }                              

            }
            return View(loginModel);
        }

        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
