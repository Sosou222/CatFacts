using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFacts
{
    public class FileManager
    {
        public string filename = "catfacts.txt";
        public string filepath = "./";

        public void Write(string textToWrite)
        {
            string file = filepath + filename;
            if(!File.Exists(file)) 
            {
                File.Create(file).Close();
            }

            File.AppendAllText(file, textToWrite + Environment.NewLine);
        }

        public void DebugReadFile()
        {
            string file = filepath + filename;
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
