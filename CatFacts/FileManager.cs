using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFacts
{
    public class FileManager
    {
        public static string Filename { get; set; } = "catfile.txt";
        public static string Filepath { get; set; } = "./";

        public static void Write(string textToWrite)
        {
            string file = Filepath + Filename;
            if(!File.Exists(file)) 
            {
                File.Create(file).Close();
            }

            File.AppendAllText(file, textToWrite + Environment.NewLine);
        }

        public static void DebugReadFile()
        {
            string file = Filepath + Filename;
            if(!File.Exists(file))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            string output = File.ReadAllText(file);
            Console.WriteLine(output);
        }
    }
}
