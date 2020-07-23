using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJwtAuthenticationService m_jwtAuthenticationManager;
        public AuthenticateController(IJwtAuthenticationService jwtAuthenticationManager)
        {
            m_jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCred userCred)
        {
            var token = await m_jwtAuthenticationManager.AuthenticateAsync(userCred.UserName, userCred.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
