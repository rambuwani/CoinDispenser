
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Coin.Dispenser.Infrastructure
{
        [JsonObject(MemberSerialization.OptIn)]
        public class ApiResponse
        {

            [JsonProperty("code")]
            public int StatusCode => (int)HttpStatusCode;

            public HttpStatusCode HttpStatusCode { get; set; }

            [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
            public string Message { get; set; }

            [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
            public object Result { get; set; }

            public ApiResponse(HttpStatusCode statusCode, string message = null, object result = null)
            {
  
                HttpStatusCode = statusCode;
                Message = message;
                Result = result;
            }

            public HttpResponseMessage BuildHttpResponseMessage()
            {
                return new HttpResponseMessage(HttpStatusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json")
                };
            }

            public static ApiResponse CreateErrorResponse(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            {
                return new ApiResponse(statusCode)
                {
                    Message = message
                };
            }

            public static ApiResponse CreateSuccessResponse(object content)
            {
                return new ApiResponse(HttpStatusCode.OK)
                {
                    Result = content
                };
            }

           
        }
    }

