using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customers.WebAPI.Controllers
{
    /// <summary>
    /// asdfasdf
    /// </summary>
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// asdfasdf
        /// </summary>
        /// <returns>asdgsd</returns>
        [Authorize]
        [HttpGet("[action]")]
        public ActionResult Secret()
        {
            return Ok(User.Claims.Select(x => $"{x.Type} {x.Value}"));
        }
    }
}