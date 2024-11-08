using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using System.Net;


namespace Application.Feature.Auth.Validatior
{
    public class LoginValidation
    {
        protected LoginViewModel _request;
        private readonly BaseResponseHandler _baseResponseHandler;
        public LoginValidation(LoginViewModel request)
        {
            _request = request;
            _baseResponseHandler = new BaseResponseHandler();
        }

        public async Task<BaseResponse<LoginResponse>> CheckValidation(CancellationToken cancellationToken)
        {
            string message = string.Empty;
            await Task.Run(() => {
                if (!BaseValidation.ValidationValueNotNull(_request.email))
                    message = "Email Can not be null";
                if (!BaseValidation.ValidationEmailAddress(_request.email))
                    message = "Email is not Valid";
                if (!BaseValidation.ValidationValueNotNull(_request.password))
                    message = "Password can not be null";
            }, cancellationToken);
            if (string.IsNullOrEmpty(message))
                return _baseResponseHandler.CheckValidation<LoginResponse>(message, false, HttpStatusCode.NotAcceptable);
            else
                return _baseResponseHandler.CheckValidation<LoginResponse>(message, true, HttpStatusCode.Accepted);
        }
    }
}
