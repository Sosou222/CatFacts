using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CatFacts
{
    public class CatFactGetter
    {
        private ConnectionClient connection;
        private HttpClient client;

        public CatFactGetter() {
            ConfigureFileManager();

            client = new HttpClient();
            ConfigureHttpClient();

            connection = new ConnectionClient(client);
        }

        public void Run()
        {
            Loop();

            DisposeHttpClient();
            Console.WriteLine("Program has ended");
        }


        private void ConfigureFileManager()
        {
            FileManager.Filename = "catfacts.txt";
            FileManager.Filepath = "./";
        }
        private void ConfigureHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://catfact.ninja");
            client.Timeout = TimeSpan.FromSeconds(2);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void Loop()
        {
            bool breakOut = false;
            while (true)
            {
                Console.WriteLine("Press 1 to get a new fact 0 to finish program");

                switch (Console.ReadLine())
                {
                    case "0":
                        breakOut = true;
                        break;

                    case "1":
                        GetFacts();
                        break;

                    default:
                        break;
                }

                if (breakOut)
                {
                    break;
                }
            }
        }

        private void GetFacts()
        {
            if (connection.TryGetRandomFact(out CatFact fact))
            {
                Console.WriteLine(fact.ToString());

                FileManager.Write(fact.ToString());
                //FileManager.DebugReadFile();
            }
            else
            {
                Console.WriteLine("Could not get Cat Fact");
            }

        }

        private void DisposeHttpClient() => client.Dispose();
    }
}
