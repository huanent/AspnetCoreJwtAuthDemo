using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AspnetCoreJwtAuthDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        [HttpGet("Token"), Produces(typeof(string))]
        public string Token()
        {
            return JwtHandler.GetToken(
                Constants.jwtKey,
                new Claim[] {
                    new Claim(ClaimTypes.Name,"huanent"),
                    new Claim(ClaimTypes.Role,"admin"),
                }, DateTime.UtcNow.AddSeconds(100));
        }

        [Authorize, HttpGet("MyInfo")]
        public string MyInfo()
        {
            return HttpContext.User.Identity.Name;
        }
    }
}