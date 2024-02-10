using Newtonsoft.Json;
using System.Collections.Generic;

namespace WhatsappApi.Dto
{
   public class BaseResponseDto<T>
    {
        public bool IsSuccess { get;  set; }
        public bool IsPartialFail { get;  set; }

        public int ReturnCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public string TransactionId { get; set; }
        public string RequestCorrelationId { get; set; }
        public List<string> Errors { get;  set; }
        public Dictionary<string, List<string>> PropErrors { get;  set; }

    }




}
