using System.Net;

namespace DescomplicaEventos.Application.ViewModel
{
    public class CustomResultError
    {
        public bool Success { get; private set; }
        public IEnumerable<string> Errors { get; protected set; }

        public CustomResultError(bool success)
        {
            Success = success;
        }

        public CustomResultError(bool success, IEnumerable<string> errors) : this(success) =>
            Errors = errors;
    }
}