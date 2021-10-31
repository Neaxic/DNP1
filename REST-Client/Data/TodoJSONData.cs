using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Data
{
    public class TodoJSONData : ITodosData
    {
        private IList<Adult> adults;

        public TodoJSONData()
        {
            adults = new List<Adult>();
            Adult loading = new Adult();
            loading.FirstName = "LOADING...";
            loading.LastName = "LOADING...";
            adults.Add(loading);
            UpdateData();
        }

        private async void UpdateData()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/Adults");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            
            
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            Console.WriteLine("Data loaded");
            
            this.adults = adults;
        }
        
        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }
        
        public async Task AddAdult(Adult adult)
        {
                using HttpClient client = new HttpClient();

                string adultJson = JsonSerializer.Serialize(adult);

                StringContent content = new StringContent(
                    adultJson,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:5001/Adult/AddAdult", content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response);
                    UpdateData();
                }
        }

        public async Task RemoveAdult(int adultID)
        {
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5001/Adult/RemoveAdult?id="+adultID);
            
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                UpdateData();
            }
        }

        /* Er basicly lavet, meeeeeen vi behøver ikke, så underlader at bug fixe det */
         
        public void Update(Adult adult)
        {
            /*
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/Adult/RemoveAdult?id="+adultID);
            
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                UpdateData();
            }*/
        } 

        public Adult get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
            /*
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Adult/GetAdult?id="+id);
            
            string result = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
            }
            
            return response;
            */
        }
    }
}