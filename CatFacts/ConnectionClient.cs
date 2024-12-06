using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CatFacts
{
    public class ConnectionClient
    {
        public CatFact GetRandomFact()
        {
            CatFact fact;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://catfact.ninja");

                var response = client.GetAsync("fact").Result;
                response.EnsureSuccessStatusCode();
                fact = response.Content.ReadFromJsonAsync<CatFact>().Result;
            }

            return fact;
        }
    }
}
