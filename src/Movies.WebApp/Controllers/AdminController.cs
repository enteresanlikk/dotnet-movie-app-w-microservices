using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.WebApp.ApiServices;

namespace Movies.WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IIdentityAPIService _identityAPIService;

        public AdminController(IIdentityAPIService identityAPIService)
        {
            _identityAPIService = identityAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var userInfo = await _identityAPIService.GetUserInfo();
            return View(userInfo);
        }
    }
}
