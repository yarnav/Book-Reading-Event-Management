using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Company.Project.Web.Models;
using Company.Project.Web.Interfaces;

namespace Company.Project.Web.Controllers
{
    public class HomeController : Controller
    {        
        private readonly IEventRepository _iEventRepository;
        private readonly ILogger<HomeController> _logger;

        public IUserService _userService { get; }

        public HomeController(IEventRepository iEventRepository, ILogger<HomeController> logger,IUserService userService)
        {
            _iEventRepository = iEventRepository;
            _logger = logger;
            _userService = userService;
        }

        [Route("")]                                                         //Index Action: Starting point
        public async Task<IActionResult> Index()
        {
            var userid = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();

            var eventList = await _iEventRepository.GetEvents();
            return View(eventList);
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("CustomerSupport")]
        public IActionResult CustomerSupport()
        {
            return Redirect("https://cas.nagarro.com/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
