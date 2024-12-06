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
        private HttpClient client;

        public ConnectionClient(HttpClient client)
        {
            this.client = client;
        }

        public CatFact GetRandomFact()
        {
            CatFact fact;

            var response = client.GetAsync("fact").Result;
            response.EnsureSuccessStatusCode();
            fact = response.Content.ReadFromJsonAsync<CatFact>().Result;

            return fact;
        }
    }
}
