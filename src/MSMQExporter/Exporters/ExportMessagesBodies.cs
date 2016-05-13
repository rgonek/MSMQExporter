using System.IO;
using System.Messaging;

namespace MSMQExporter.Exporters
{
    public class ExportMessagesBodies : IExportingQueue
    {
        private const int log_message_interval = 100;

        public void Export(string queueName, string directoryPath, int? messagesToProcess)
        {
            CreateDirectoryIfNotExists(directoryPath);

            ExportMessages(queueName, directoryPath, messagesToProcess);
        }

        private void ExportMessages(string queueName, string directoryPath, int? messagesToProcess)
        {
            var queue = new Queue(queueName);
            queue.Enumerates(
                message => SaveMessageBody(directoryPath, message),
                messagesToProcess);
        }

        private void SaveMessageBody(string directoryPath, Message message)
        {
            var fileName = get_file_name(directoryPath, message.Id);
            File.WriteAllText(fileName, message.BodyStream.ToText());
        }

        private void CreateDirectoryIfNotExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        private string get_file_name(string directoryPath, string messageId)
        {
            return Path.Combine(
                directoryPath,
                messageId.ReplaceInvalidPathCharacters("_") + ".xml");
        }
    }
}
