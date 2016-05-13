using System.IO;
using System.Linq;

namespace MSMQExporter.Exporters
{
    public static class StringExtensions
    {
        public static string ReplaceInvalidPathCharacters(
            this string fileName, 
            string newString)
        {
            return Path.GetInvalidFileNameChars()
                .Aggregate(
                    fileName, 
                    (current, c) => 
                        current.Replace(c.ToString(), newString)
                );
        }
    }
}
