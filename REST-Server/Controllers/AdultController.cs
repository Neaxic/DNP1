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
    public class AdultController : ControllerBase
    {
        public ITodosData Adultdata = new TodoJSONData();

        private readonly ILogger<AdultController> _logger;
        private IList<Adult> adults;

        public AdultController(ILogger<AdultController> logger)
        {
            _logger = logger;
            adults = Adultdata.GetAdults();
        }

        [HttpGet("~/Adults")]
        public IEnumerable<Adult> Get()
        {
            return Enumerable.Range(1, adults.Count).Select(index => new Adult
                {
                    JobTitle = new Job
                    {
                        JobTitle = adults[index-1].JobTitle.JobTitle,
                        Salary = adults[index-1].JobTitle.Salary
                    },
                    Id = adults[index-1].Id,
                    FirstName = adults[index-1].FirstName,
                    LastName = adults[index-1].LastName,
                    HairColor = adults[index-1].HairColor,
                    EyeColor = adults[index-1].EyeColor,
                    Age = adults[index-1].Age,
                    Weight = adults[index-1].Weight,
                    Height = adults[index-1].Height,
                    Sex = adults[index-1].Sex,
                })
                .ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                Adultdata.AddAdult(adult);
                return Ok(adults);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> RemoveAdult([FromQuery] int id)
        {
            try
            {
                Adultdata.RemoveAdult(id);
                return Ok(adults);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> Update([FromBody] Adult adult)
        {
            try
            {
                Adultdata.Update(adult);
                return Ok(adults);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<int>> GetOne([FromQuery] int id)
        {
            try
            {
                Adult specific = Adultdata.get(id);
                return Ok(specific);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}