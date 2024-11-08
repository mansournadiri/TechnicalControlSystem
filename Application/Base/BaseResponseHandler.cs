using System.Net;

namespace Application.Base
{
    public class BaseResponseHandler
    {
        public BaseResponse<T> Deleted<T>()
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "DeletedSuccessfully"
            };
        }

        public BaseResponse<T> Success<T>(T entity, object? meta)
        {
            return new BaseResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Successfully",
                Meta = meta
            };
        }

        public BaseResponse<T> Unauthorized<T>()
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }

        public BaseResponse<T> BadRequest<T>(string message, List<string> errors)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? "BadRequest" : message,
                Errors = errors
            };
        }

        public BaseResponse<T> Conflict<T>(string message)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.Conflict,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? "Conflict" : message
            };
        }

        public BaseResponse<T> UnprocessableEntity<T>(string message)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? "UnprocessableEntity" : message
            };
        }

        public BaseResponse<T> NotFound<T>(string message)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? "NotFound" : message
            };
        }

        public BaseResponse<T> Created<T>(T entity, object meta)
        {
            return new BaseResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = meta
            };
        }

        public BaseResponse<T> CheckValidation<T>(string message, bool Succeeded, HttpStatusCode httpStatusCode)
        {
            return new BaseResponse<T>()
            {
                StatusCode = httpStatusCode,
                Succeeded = Succeeded,
                Message = message,
            };
        }
    }
}
