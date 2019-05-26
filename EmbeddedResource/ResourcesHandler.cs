using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmbeddedResource
{
    class ResourcesHandler
    {
        static public Stream GetResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(name));

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            return stream;
        }
    }
}
