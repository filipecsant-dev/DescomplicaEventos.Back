using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DescomplicaEventos.Application.ViewModel.Shared
{
    public class ErrorResponseVM : CustomResult
    {
        public string TraceId { get; private set; }

        public ErrorResponseVM(HttpStatusCode statusCode, bool success) : base(statusCode, success)
        {
            TraceId = Guid.NewGuid().ToString();
        }

        public ErrorResponseVM(HttpStatusCode statusCode, bool success, List<string> errors) : base(statusCode, success, errors)
        {
            TraceId = Guid.NewGuid().ToString();
        }
    }
}