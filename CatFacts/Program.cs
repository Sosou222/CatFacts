namespace CatFacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager.Filename = "catfacts.txt";
            FileManager.Filepath = "./";

            ConnectionClient client = new ConnectionClient();

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

            Console.WriteLine("Program has ended");
        }

        private static void GetFacts(ConnectionClient client)
        {
            var fact = client.GetRandomFact();
            Console.WriteLine(fact.ToString());

            FileManager.Write(fact.Fact);
            FileManager.DebugReadFile();
        }
    }
}
