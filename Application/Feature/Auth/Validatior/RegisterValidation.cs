using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using MediatR;
using System.Net;

namespace Application.Feature.Auth.Validatior
{
    public class RegisterValidation
    {
        protected RegisterViewModel _request;
        private readonly BaseResponseHandler _baseResponseHandler;

        public RegisterValidation(RegisterViewModel request)
        {
            _request = request;
            _baseResponseHandler = new BaseResponseHandler();
        }
        public async Task<BaseResponse<LoginResponse>> CheckValidation(CancellationToken cancellationToken)
        {
            string message = string.Empty;
            await Task.Run(() =>
            {
                if (!BaseValidation.ValidationValueNotNull(_request.companyName))
                    message = "Company Name Can not be null";

                if (!BaseValidation.ValidationValueNotNull(_request.companyIdentity))
                    message = "Company Identity Can not be null";
                if (!BaseValidation.ValidationNumber(_request.companyIdentity))
                    message = "Company Identity id invalid";

                if (!BaseValidation.ValidationNationalId(_request.nationalID))
                    message = "National ID is invalid";

                if (!BaseValidation.ValidationMobileNumber(_request.mobileNumber))
                    message = "Mobile Number is invalid";

                if (!BaseValidation.ValidationEmailAddress(_request.mailAddress))
                    message = "Email Address is invalid";
            }, cancellationToken);

            if (string.IsNullOrEmpty(message))
                return _baseResponseHandler.CheckValidation<LoginResponse>(message, true, HttpStatusCode.Accepted);
            else
                return _baseResponseHandler.CheckValidation<LoginResponse>(message, false, HttpStatusCode.NotAcceptable);
        }
    }
}
