using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmbeddedResource
{
    class Program
    {
        static void Main(string[] args)
        {
            string result;
            using (var str = new StreamReader(ResourcesHandler.GetResource("plik.txt")))
            {
                result = str.ReadToEnd();
            }

                Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
