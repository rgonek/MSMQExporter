using System.IO;

namespace MSMQExporter.Exporters
{
    public static class StreamExtensions
    {
        public static string ToText(this Stream stream)
        {
            stream.Position = 0;
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
