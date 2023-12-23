using System.Net;
using DescomplicaEventos.Application.ViewModel;
using Newtonsoft.Json;

namespace DescomplicaEventos.API.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //TODO: Gravar log de erro com o trace id

            ErrorResponseVM errorResponseVM;
            var errors = new List<string>();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Qa")
            {
                errors.Add($"{ex.Message} {ex?.InnerException?.Message}");
                errorResponseVM = new ErrorResponseVM(false, errors);
            }
            else
            {
                errors.Add("Ocorreu um erro interno do servidor.");
                errorResponseVM = new ErrorResponseVM(false, errors);
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorResponseVM);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}