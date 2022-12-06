using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Controllers
{
    [Route("api/identity")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet("claims")]
        public IActionResult GetClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
