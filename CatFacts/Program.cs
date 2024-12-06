using System.Net.Http.Headers;

namespace CatFacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CatFactGetter catFactGetter = new CatFactGetter();
            catFactGetter.Run();
        }
    }
}
