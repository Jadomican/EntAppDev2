using System;

namespace RestfulLabSMSClient
{
    public class TextMessage
    {
        public String SourceNumber { get; set; }
        public String DestinationNumber { get; set; }
        public String Content { get; set; }
    }
}
