using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DescomplicaEventos.Application.ViewModel.Shared
{
    public class CustomResult
    {
        public HttpStatusCode StatusCode { get; private set; }
        public bool Success { get; private set; }
        public object Data { get; private set; }
        public IEnumerable<string> Errors { get; protected set; }
        
        public CustomResult(HttpStatusCode statusCode, bool success)
        {
            StatusCode = statusCode;
            Success = success;
        }

        public CustomResult(HttpStatusCode statusCode, bool success, object data) : this(statusCode, success) =>
            Data = data;

        public CustomResult(HttpStatusCode statusCode, bool success, IEnumerable<string> errors) : this(statusCode, success) =>
            Errors = errors;

        public CustomResult(HttpStatusCode statusCode, bool success, object data, IEnumerable<string> errors) : this(statusCode, success, data) =>
            Errors = errors;
    }
}