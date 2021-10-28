using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Data;

namespace REST_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private readonly ILogger<AdultController> _logger;
        private IList<Adult> adults;

        public AdultController(ILogger<AdultController> logger)
        {
            _logger = logger;
            adults = new List<Adult>(2);
            adults.Add(new Adult
            {
                JobTitle = new Job
                {
                    JobTitle = "Front End Web Developer",
                    Salary = 66408,
                },
                Id = 1,
                FirstName = "Lyla",
                LastName = "Humphrey",
                HairColor = "Black",
                EyeColor = "Brown",
                Age = 36,
                Weight = 64,
                Height = 147,
                Sex = "F"
            });
            adults.Add(new Adult
            {
                JobTitle = new Job
                {
                    JobTitle = "Front End Web Developer",
                    Salary = 66408,
                },
                Id = 1,
                FirstName = "Bente",
                LastName = "Humphrey",
                HairColor = "Black",
                EyeColor = "Brown",
                Age = 36,
                Weight = 64,
                Height = 147,
                Sex = "F"
            });
        }

        [HttpGet]
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
    }
}