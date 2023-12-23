using System.Net;
using DescomplicaEventos.API.Extensions;
using DescomplicaEventos.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DescomplicaEventos.API.Controllers.Shared
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult ResponseOk(object result) =>
            Response(HttpStatusCode.OK, result);

        protected IActionResult ResponseOk() =>
            Response(HttpStatusCode.OK);

        protected IActionResult ResponseCreated() =>
            Response(HttpStatusCode.Created);
        
        protected IActionResult ResponseCreated(object data) =>
            Response(HttpStatusCode.Created, data);

        protected IActionResult ResponseNoContent() =>
            Response(HttpStatusCode.NoContent);

        protected IActionResult ResponseNotModified() =>
            Response(HttpStatusCode.NotModified);

        protected IActionResult ResponseBadRequest(IEnumerable<string> errors) =>
            Response(HttpStatusCode.BadRequest, errors);

        protected IActionResult ResponseBadRequest() =>
            Response(HttpStatusCode.BadRequest, errorMessage: "A requisição é inválida");

        protected IActionResult ResponseNotFound(IEnumerable<string> errors) =>
            Response(HttpStatusCode.NotFound, errors);

        protected IActionResult ResponseNotFound() =>
            Response(HttpStatusCode.NotFound, errorMessage: "O recurso não foi encontrado");

        protected IActionResult ResponseUnauthorized(IEnumerable<string> errors) =>
            Response(HttpStatusCode.Unauthorized, errors);

        protected IActionResult ResponseUnauthorized() =>
            Response(HttpStatusCode.Unauthorized, errorMessage: "Permissão negada");

        protected IActionResult ResponseInternalServerError() =>
            Response(HttpStatusCode.InternalServerError);
        
        protected IActionResult ResponseInternalServerError(string errorMessage) =>
            Response(HttpStatusCode.InternalServerError, errorMessage: errorMessage);

        protected IActionResult ResponseInternalServerError(Exception exception) =>
            Response(HttpStatusCode.InternalServerError, errorMessage: exception.Message);

        protected new JsonResult Response(HttpStatusCode statusCode, object data,  IEnumerable<string> errors)
        {
            var result = new object();

            if (errors == null)
            {
                var success = statusCode.IsSuccess();

                if (data != null)
                    result = new CustomResultSuccess(success, data);
                else
                    result = new CustomResultSuccess(success);
            }
            else
            {
                result = new CustomResultError(false, errors);
            }
            return new JsonResult(result);
        }

        protected new JsonResult Response(HttpStatusCode statusCode, object result) =>
            Response(statusCode, result, null);

        protected new JsonResult Response(HttpStatusCode statusCode, IEnumerable<string> errors) =>
            Response(statusCode, null, errors);

        protected new JsonResult Response(HttpStatusCode statusCode, string errorMessage)
        {
            var errors = new List<string>();
            errors.Add(errorMessage);

            return Response(statusCode, null, errors);
        }
            

        protected new JsonResult Response(HttpStatusCode statusCode) =>
            Response(statusCode, null, null);
    }
}