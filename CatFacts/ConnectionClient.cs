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

        public bool TryGetRandomFact(out CatFact fact)
        {
            try
            {
                var response = client.GetAsync("fact").Result;
                response.EnsureSuccessStatusCode();
                fact = response.Content.ReadFromJsonAsync<CatFact>().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                fact = new CatFact()
                {
                    Fact = "Invalid",
                    Length = 0,
                };
                return false;
            }

            return true;
        }
    }
}
