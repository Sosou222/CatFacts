namespace CatFacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager.Filename = "catfacts.txt";
            FileManager.Filepath = "./";

            ConnectionClient client = new ConnectionClient();

            var fact = client.GetRandomFact();
            Console.WriteLine(fact.ToString());

            FileManager.Write(fact.Fact);
            FileManager.DebugReadFile();

            
        }
    }
}
