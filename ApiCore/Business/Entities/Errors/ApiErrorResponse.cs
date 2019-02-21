using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCore.Business.Entities.Errors
{

    [Serializable]
       public class ApiErrorResponse
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string ReasonPhrase { get; set; }

        public ApiErrorResponse(int errorCode, string description, string reasonPhrase)
        {
            Code = errorCode;
            Description = description;
            ReasonPhrase = reasonPhrase;
        }
    }
}
