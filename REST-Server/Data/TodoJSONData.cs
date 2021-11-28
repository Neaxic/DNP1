using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using REST_Server;
using REST_Server.DataAccess;

namespace Data
{
    public class TodoJSONData : ITodosData
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;
        private IList<User> users;

        public TodoJSONData()
        {
            adults = new List<Adult>();
            users = new List<User>();
            //SeedDB();
            readDB();
        }

        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }
        
        public IList<User> GetUsers()
        {
            List<User> tmp = new List<User>(users);
            return tmp;
        }

        private IList<Adult> readJson()
        {
            List<Adult> returnList = new List<Adult>();
            if (!File.Exists(adultFile))
            {
                //Seed();
                string todosAsJson = JsonSerializer.Serialize(adults);
                File.WriteAllText(adultFile, todosAsJson);
            }
            else //Den der kommer til at køre altid ved seed
            {
                Console.WriteLine("> LÆSER JSON ... ");
                string content = File.ReadAllText(adultFile);
                returnList = JsonSerializer.Deserialize<List<Adult>>(content);
            }

            return returnList;
        }

        public async Task readDB()
        {
            IList<Job> jobs = new List<Job>();
            IList<Adult> adultsWithoutJob = new List<Adult>();

            using (DataDBContext dbContext = new DataDBContext())
            {
                adultsWithoutJob = dbContext.adults.ToList();
                jobs = dbContext.jobs.ToList();
                users = dbContext.users.ToList();
            }

            int index = 0;

            foreach (var i in adultsWithoutJob)
            {
                Adult a = new Adult()
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    HairColor = i.HairColor,
                    EyeColor = i.EyeColor,
                    Age = i.Age,
                    Weight = i.Weight,
                    Height = i.Height,
                    Sex = i.Sex,
                    JobTitle = jobs[index]
                };
                adults.Add(a);
                index++;
            }
        }

        public async Task SeedDB()
        {
            IList<Adult> JsonData = new List<Adult>();
            JsonData = readJson();

            User u1 = new User()
            {
                UserName = "lvl1",
                Password = "123",
                Role = "Mod",
                SecurityLevel = 1
            };

            User u2 = new User()
            {
                UserName = "lvl2",
                Password = "123",
                Role = "Admin",
                SecurityLevel = 2
            };

            users.Add(u1);
            users.Add(u2);

            foreach (var i in JsonData)
            {
                Adult person = new Adult()
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    HairColor = i.HairColor,
                    EyeColor = i.EyeColor,
                    Age = i.Age,
                    Weight = i.Weight,
                    Height = i.Height,
                    Sex = i.Sex,
                    JobTitle = i.JobTitle
                };

                person.JobTitle.jobId = 0;

                Console.WriteLine("> " + person.Id + ", " + person.FirstName + " " + person.LastName + ", " +
                                  person.HairColor + person.EyeColor + person.Age + person.Weight + person.Height +
                                  person.Sex + person.JobTitle.JobTitle);

                using (DataDBContext dbContext = new DataDBContext())
                {
                    await dbContext.jobs.AddAsync(person.JobTitle);
                    await dbContext.adults.AddAsync(person);
                    await dbContext.SaveChangesAsync();
                }
            }

            foreach (var VARIABLE in users)
            {
                using (DataDBContext dbContext = new DataDBContext())
                {
                    await dbContext.users.AddAsync(VARIABLE);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task AddAdult(Adult adult)
        {
            adults.Add(adult);
            using (DataDBContext dbContext = new DataDBContext())
            {
                await dbContext.adults.AddAsync(adult);
                await dbContext.SaveChangesAsync();
            }
        }

        public void RemoveAdult(int adultID)
        {
            Adult toRemove = adults.First(t => t.Id == adultID);
            adults.Remove(toRemove);
            using (DataDBContext dbContext = new DataDBContext())
            {
                IQueryable<Adult> result = dbContext.adults.Where(c => c.Id.Equals(adultID));
                dbContext.adults.Remove(result.First());
                dbContext.SaveChangesAsync();
            }
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            adults.Remove(toUpdate);
            adults.Add(adult);
            
            using (DataDBContext dbContext = new DataDBContext())
            {
                IQueryable<Adult> result = dbContext.adults.Where(c => c.Id.Equals(adult.Id));

                result.First().Id = adult.Id;
                result.First().FirstName = adult.FirstName;
                result.First().LastName = adult.LastName;
                result.First().HairColor = adult.HairColor;
                result.First().EyeColor = adult.EyeColor;
                result.First().Age = adult.Age;
                result.First().Weight = adult.Weight;
                result.First().Height = adult.Height;
                result.First().Sex = adult.Sex;
                result.First().JobTitle = adult.JobTitle;
                
                dbContext.adults.Update(result.First());
                dbContext.SaveChangesAsync();
            }
            
        }

        public Adult get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }
    }
}