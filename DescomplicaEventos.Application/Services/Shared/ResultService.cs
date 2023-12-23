using FluentValidation.Results;

namespace DescomplicaEventos.Application.Services.Shared
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ICollection<string> Errors { get; set; }
        
        public static ResultService RequestError(string Message, ValidationResult  validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = Message,
                Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
            };    
        }

        public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Message = message };

        public static ResultService Ok(string message) => new ResultService { IsSuccess = true, Message = message };

    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }

        public static ResultService<T> RequestError(string Message, ValidationResult  validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = Message,
                Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
            };    
        }

        public static ResultService<T> Fail(string message) => new ResultService<T> { IsSuccess = false, Message = message };

        public static ResultService<T> Ok(T data) => new ResultService<T> { IsSuccess = true, Data = data };

    }
}