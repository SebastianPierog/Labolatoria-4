using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using System.Linq;


namespace Zadanie
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var db = new FootballContext();
            db.Database.EnsureCreated();
            
            var client = new RestClient("https://api.collegefootballdata.com/");
            var request = new RestRequest($"/teams/fbs?year=2019", Method.GET);
            
            var response = await client.ExecuteAsync(request);

            var content = response.Content;

            var teams = JsonSerializer.Deserialize<Teams[]>(content,
              
            new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

            
            var tasks = new List<Task<IRestResponse>>();
            foreach (var team in teams)
            {
                var coathRequest = new RestRequest($"/coaches?team={team.School}&year=2019", Method.GET);
                tasks.Add(client.ExecuteAsync(coathRequest));
                
            }

            var res = await Task.WhenAll(tasks);
            var coaches = res.SelectMany(x => JsonSerializer.Deserialize<Coaches[]>(x.Content,
                new JsonSerializerOptions(){PropertyNameCaseInsensitive = true}) );
            
            
            foreach (var coach in coaches)
            {
                teams.Single( x => 
                    x.School == coach.Seasons.First().School).Coacheses.Add(coach);
            }

            var addTask = teams.Select(x => db.AddAsync(x).AsTask());
            await Task.WhenAll(addTask);
            await db.SaveChangesAsync();


        }
    }
}