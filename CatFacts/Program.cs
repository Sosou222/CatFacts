namespace CatFacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            fileManager.Write("Test");
            fileManager.DebugReadFile();
        }
    }
}
