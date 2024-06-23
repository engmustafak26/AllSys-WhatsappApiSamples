using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WhatsappApi.Dto.Responses
{
    public class EmptyResponseDto
    {
    }

    public class MessageIdDto
    {
        public long MessageId { get; set; }    
    }

    public class GetOtpMessageStatusResponseDto
    {
        public DateTime? SendDate { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
