using System;
using System.IO;

namespace LoadXmlIgnoreVersion
{
    public static class TestMethods
    {
        private const string xmlSubDir = "docs/";
        public static string FullXmlPath(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, xmlSubDir, fileName);
            return path.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
        }
    }
}
