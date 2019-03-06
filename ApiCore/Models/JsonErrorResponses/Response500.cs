using Newtonsoft.Json;
using System;

namespace ApiCore.Models.JsonErrorResponses
{
    public class Response500    
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public Response500(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public Response500(Exception ex)
        {
            Code = ex.HResult;
            Message = ex.Message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
