using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace REST_Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<AdultController> _logger;
        private IList<User> logins;
        public ITodosData data = new TodoJSONData();

        public LoginController(ILogger<AdultController> logger)
        {
            _logger = logger;
            logins = data.GetUsers();
        }

        [HttpGet]
        public async Task<ActionResult<String>> ValidateLogin([FromQuery] string username, string pass)
        {
            try
            {
                foreach (var i in logins)
                {
                    if (i.UserName == username && i.Password == pass)
                    {
                        return Ok(i);
                    }
                }
                
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> allLogins()
        {
            try
            {
                return Ok(logins);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}