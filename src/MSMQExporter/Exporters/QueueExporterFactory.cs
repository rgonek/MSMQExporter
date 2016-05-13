namespace MSMQExporter.Exporters
{
    public class QueueExporterFactory
    {
        public static IExportingQueue GetExporter(ExportType type)
        {
            switch (type)
            {
                case ExportType.Body:
                    return new ExportMessagesBodies();
                case ExportType.Properties:
                    return new ExportMessagesProperties();
            }

            return null;
        }
    }
}
