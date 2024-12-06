using System.Net.Http.Headers;

namespace CatFacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager.Filename = "catfacts.txt";
            FileManager.Filepath = "./";


            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("https://catfact.ninja");
            http.Timeout = TimeSpan.FromSeconds(2);
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ConnectionClient client = new ConnectionClient(http);

            bool breakOut = false;
            while(true)
            {
                Console.WriteLine("Press 1 to get a new fact 0 to finish program");

                switch (Console.ReadLine())
                {
                    case "0":
                        breakOut = true;
                        break;

                    case "1":
                        GetFacts(client);
                        break;

                    default:
                        break;
                }

                if(breakOut)
                {
                    break;
                }
            }

            http.Dispose();
            Console.WriteLine("Program has ended");
        }

        private static void GetFacts(ConnectionClient client)
        {
            if (client.TryGetRandomFact(out CatFact fact))
            {
                Console.WriteLine(fact.ToString());

                FileManager.Write(fact.Fact);
                FileManager.DebugReadFile();
            }
            else
            {
                Console.WriteLine("Could not get Cat Fact");
            }
            
        }
    }
}
