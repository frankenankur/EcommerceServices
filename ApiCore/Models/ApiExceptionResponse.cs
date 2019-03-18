using ApiCore.Models.Enumerations;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ApiCore.Models
{
    [Serializable]
    public class ApiExceptionResponse
    {     
        [Required]
        public HttpStatusCode HttpStatusCode { get; set; }

        public string ErrorType { get; }

        public string UserMessage { get; }
       
        public string DeveloperMessage { get; }

        public int ErrorCode { get; }
        public string Source { get; }

        [Required]
        public string TrackingId { get; set; }

        private string GetErrorType() {

            var statusCode = (int)HttpStatusCode;
            var firstDigit = (statusCode / 100) % 10;
            var returnvalue = ApiErrorTypes.Unknown;
            switch (firstDigit)
            {
                case 1:
                    returnvalue = ApiErrorTypes.Informational;
                    break;
                case 3:
                    returnvalue = ApiErrorTypes.Redirection;
                    break;
                case 4:
                    returnvalue = ApiErrorTypes.ClientError;
                    break;
                case 5:
                    returnvalue = ApiErrorTypes.ServerError;
                    break;
                default:
                    returnvalue = ApiErrorTypes.Unknown;
                    break;
            }

            return returnvalue.ToString();
        }

        private string GetUserMessage()
        {
            var returnValue = "Unspecified error. See response body for details.";

            switch (HttpStatusCode)
            {
                case HttpStatusCode.BadRequest:
                    returnValue = "Request error. See response body for details.";
                    break;
                case HttpStatusCode.Unauthorized:
                    returnValue = "Authentication failure, invalid access credentials.";
                    break;
                case HttpStatusCode.Forbidden:
                    returnValue = "Insufficient permission.";
                    break;
                case HttpStatusCode.InternalServerError:
                    returnValue = "Unspecified internal server error. See response body for details.";
                    break;
                default:
                    returnValue = "Unspecified error. See response body for details.";
                    break;
            }

            return returnValue;
        }

        public ApiExceptionResponse(HttpStatusCode httpStatusCode, Exception innerException, string trackingId, bool showDeveloperExceptionDetails)
        {
            HttpStatusCode = httpStatusCode;
            ErrorType = GetErrorType();
            UserMessage = GetUserMessage();
            ErrorCode = innerException.HResult;
            TrackingId = trackingId;

            if (showDeveloperExceptionDetails)
            {
                DeveloperMessage = innerException.Message;
                Source = innerException.Source;
            }
        }
    }
}
