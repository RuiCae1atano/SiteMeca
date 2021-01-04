using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiteMercado.Api.Login.Intefaces;
using SiteMercado.Api.Login.Models;

namespace SiteMercado.Api.Login.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly IUserLogin userLogin;

        public LoginApiController(IUserLogin userLogin)
        {
            this.userLogin = userLogin;
        }

        //CADASTRA POST api/<ValuesController>
        [HttpPost]
        public IActionResult LoginUser([FromBody] Usuario value)
        {
            var result = userLogin.LoginUser(value);

            if ((bool)result["success"])
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
