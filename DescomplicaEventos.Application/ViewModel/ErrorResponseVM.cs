using System.Net;
using DescomplicaEventos.Application.Services.Shared;

namespace DescomplicaEventos.Application.ViewModel
{
    public class ErrorResponseVM : CustomResultError
    {
        public string TraceId { get; private set; }

        public ErrorResponseVM(bool success, IEnumerable<string> errors) : base(success, errors)
        {
            TraceId = Guid.NewGuid().ToString();
        }
    }
}