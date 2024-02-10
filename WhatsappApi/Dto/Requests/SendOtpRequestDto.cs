using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappApi.Dto.Requests
{
    public class SendOtpRequestDto
    {
        public string Message { get; set; }
        public string Number { get; set; }
    }
}
