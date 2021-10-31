using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Models
{
    public class InMemoryUserService : IUserService
    {
        public async Task<User> ValidateUser(string username, string password)
        {
            using HttpClient client = new HttpClient();

            HttpResponseMessage response =
                await client.GetAsync("https://localhost:5001/Login/ValidateLogin?username=" + username + "&pass=" +password);

            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");

            string result = await response.Content.ReadAsStringAsync();
            User login = JsonSerializer.Deserialize<User>(result);
            Console.WriteLine(result);

            return login;
        }
/*
        private async void allUsers()
        {
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Login/allLogins");

            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync();

            List<User> users = JsonSerializer.Deserialize<List<User>>(result);
            foreach (var VARIABLE in users)
            {
             Console.WriteLine(VARIABLE.UserName);   
            }
            userlist = users;
        }
    */
    }
}