# MSMQExporter
Exports MSMQ Queue messages.

##Parameters
###Required

__Queue name__ (-q, --queue)

Queue name to export. Format: [Environment Name]\\[Queue Name].
  
__Path__ (-p, --path)

Path to file (for properties type) or directory (for body type).

###Optional

__Export type__ (-t, --type)

Export type. Default = Body. 

_Body_ - save body of each message to separate xml file with message id in name. 

_Properties_ - save messaages properties to csv file with ';' as separators.

__Messages to export__ (-c, --count)

Quantity of messages to export. If not specified all messages will be exported.

##Example
    MSMQExporter.exe -q="ROBERT-THINKPAD\private$\test_queue" -p="E:\test" -t=Body
