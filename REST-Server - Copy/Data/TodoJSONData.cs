using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;
using REST_Server;

namespace Data
{
    public class TodoJSONData : ITodosData
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public TodoJSONData()
        {
            if (!File.Exists(adultFile))
            {
                //Seed();
                string todosAsJson = JsonSerializer.Serialize(adults);
                File.WriteAllText(adultFile, todosAsJson);
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }
        
        public void AddAdult(Adult adult)
        {
            //Generer adult ID
            int currIndex = adults.Max(adult => adult.Id);
            adult.Id = (++currIndex);

            adults.Add(adult);
            string todosAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, todosAsJson);

        }

        public void RemoveAdult(int adultID)
        {
            Adult toRemove = adults.First(t => t.Id == adultID);
            adults.Remove(toRemove);
            string adultsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, adultsAsJson);
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            adults.Remove(toUpdate);
            adults.Add(adult);
            
            string adultsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, adultsAsJson);
        }

        public Adult get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }
    }
}