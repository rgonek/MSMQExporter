namespace MSMQExporter.Exporters
{
    public interface IExportingQueue
    {
        void Export(string queueName, string path, int? quantity);
    }
}
