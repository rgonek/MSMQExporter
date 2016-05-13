using NDesk.Options;
using System;

namespace MSMQExporter
{
    public class Options
    {
        public string QueueName { get; set; }
        public string FileName { get; set; }
        public int? MessagesToProcess { get; set; }
        public ExportType? Type { get; set; } = ExportType.Body;

        public static Options Parse(string[] args)
        {
            var options = new Options();
            var optionSet = new OptionSet
            {
                { "q=|queue=", "{Queue name} to export.\nFormat: [Environment Name]\\[Queue Name]", v => options.QueueName = v },
                { "p=|path=", "{Path} to file (for definitions type) or directory (for body type).", v => options.FileName = v },
                { "c:|count:", "{Quantity} of messages to export. If not specified all messages will be processed.", (int? v) => options.MessagesToProcess = v },
                { "t:|type:", "{Export type}. Default = Body.\nBody - save body of each message to separate xml file with message " +
                    "id in name.\nProperties - save messaages properties to csv file with ';' as separators.", (ExportType v) => options.Type = v },
            };

            try
            {
                optionSet.Parse(args);
            }
            catch (OptionException e)
            {
                Console.WriteLine(e.Message);
            }

            if (string.IsNullOrWhiteSpace(options.QueueName))
            {
                optionSet.WriteOptionDescriptions(Console.Out);
                Environment.Exit(10);
            }
            if (string.IsNullOrWhiteSpace(options.FileName))
            {
                optionSet.WriteOptionDescriptions(Console.Out);
                Environment.Exit(11);
            }
            if (options.Type.HasValue == false)
            {
                optionSet.WriteOptionDescriptions(Console.Out);
                Environment.Exit(12);
            }

            return options;
        }
    }
}