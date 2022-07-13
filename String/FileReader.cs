using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    internal static class FileReader
    {
        public static string ReadFile(string filePath)
        {
            string text;
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch
            {
                text = "";
            }
            return text;
        }
    }
}
