using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();

            string[] list = System.IO.Directory.GetDirectories("C:\\movies");

            Console.WriteLine("Gevonden directories:");

            foreach (string s in list)
            {
                Console.Write(s + "  : ");
                Movie m = new Movie();
                m.FolderName = System.IO.Path.GetDirectoryName(s);
                Console.WriteLine(m.GetFirstPart());
            }



            Console.ReadKey();
            
        }
    }
}
