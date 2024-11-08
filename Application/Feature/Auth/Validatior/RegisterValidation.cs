using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
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
                    message = "نام شرکت نمی‌تواند خالی باشد.";

                if (!BaseValidation.ValidationValueNotNull(_request.companyIdentity))
                    message = "شناسه اقتصادی شرکت نمی‌تواند خالی باشد.";
                if (!BaseValidation.ValidationNumber(_request.companyIdentity))
                    message = "شناسه اقتصادی شرکت نامعتبر است.";

                if (!BaseValidation.ValidationNationalId(_request.nationalID))
                    message = "کدملی وارد شده معتبر نیست.";

                if (!BaseValidation.ValidationMobileNumber(_request.mobileNumber))
                    message = "شماره تماس وارد شده معتبر نیست.";

                if (!BaseValidation.ValidationEmailAddress(_request.mailAddress))
                    message = "پست الکترونیکی وارد شده معتبر نیست.";
            }, cancellationToken);

            if (string.IsNullOrEmpty(message))
                return _baseResponseHandler.CheckValidation<LoginResponse>(message, true, HttpStatusCode.Accepted);
            else
                return _baseResponseHandler.CheckValidation<LoginResponse>(message, false, HttpStatusCode.NotAcceptable);
        }
    }
}
