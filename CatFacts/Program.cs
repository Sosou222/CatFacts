namespace CatFacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionClient client = new ConnectionClient();

            var fact = client.GetRandomFact();
            Console.WriteLine(fact.ToString());
            FileManager fileManager = new FileManager();
            fileManager.Write(fact.Fact);
            fileManager.DebugReadFile();

            
        }
    }
}
