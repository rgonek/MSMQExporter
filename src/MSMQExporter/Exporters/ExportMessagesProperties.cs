using System.IO;
using System.Messaging;

namespace MSMQExporter.Exporters
{
    public class ExportMessagesProperties : IExportingQueue
    {
        public void Export(string queueName, string fileName, int? messagesToProcess)
        {
            var queue = new Queue(queueName, readAllProperties: true);

            File.AppendAllLines(fileName, new[] { "Label;BodySize;SentTime;Priority;Id" });

            queue.Enumerates(
                message => SaveMessageProperties(fileName, message),
                messagesToProcess);
        }

        private void SaveMessageProperties(string fileName, Message message)
        {
            File.AppendAllLines(
                fileName,
                new[] { $"{message.Label};{message.BodyStream.Length};{message.SentTime};{message.Priority};{message.Id}" });
        }
    }
}
