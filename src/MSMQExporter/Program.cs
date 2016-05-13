using MSMQExporter.Exporters;
using System;

namespace MSMQExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = Options.Parse(args);

            var exporter = QueueExporterFactory.GetExporter(options.Type.Value);
            exporter.Export(options.QueueName, options.FileName, options.MessagesToProcess);

            Console.WriteLine("Queue exported.");
        }
    }
}
