using System;
using System.Messaging;

namespace MSMQExporter
{
    public class Queue
    {
        private const int log_message_interval = 100;

        private readonly string _name;
        private readonly bool _readAllProperties; 

        public Queue(string name, bool readAllProperties = false)
        {
            _name = name;
            _readAllProperties = readAllProperties;
        }

        public void Enumerates(Action<Message> messageAction, int? messagesToProcess)
        {
            var enumerator = GetMessageEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                index++;
                var message = enumerator.Current;

                messageAction(message);

                if (messagesToProcess.HasValue && index == messagesToProcess.Value)
                    break;

                log_message(index);
            }
        }

        private MessageEnumerator GetMessageEnumerator()
        {
            var queue = new MessageQueue(_name);
            queue.Formatter = new ActiveXMessageFormatter();
            if (_readAllProperties)
                queue.MessageReadPropertyFilter.SetAll();

            return queue.GetMessageEnumerator2();
        }

        private void log_message(int index)
        {
            if (index % log_message_interval == 0)
                Console.WriteLine("Messages processed: " + index);
        }
    }
}
