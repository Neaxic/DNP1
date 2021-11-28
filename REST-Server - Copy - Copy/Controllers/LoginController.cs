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

        public LoginController(ILogger<AdultController> logger)
        {
            _logger = logger;
            logins = new List<User>();

            User lvl1 = new User();
            lvl1.UserName = "lvl1";
            lvl1.Password = "123";
            lvl1.Role = "Mod";
            lvl1.SecurityLevel = 1;
            
            User lvl2 = new User();
            lvl2.UserName = "lvl2";
            lvl2.Password = "123";
            lvl2.Role = "Admin";
            lvl2.SecurityLevel = 2;
            
            logins.Add(lvl1);
            logins.Add(lvl2);
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