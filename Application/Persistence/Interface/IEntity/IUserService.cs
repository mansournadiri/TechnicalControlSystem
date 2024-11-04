using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using Domain.Entity;

namespace Application.Persistence.Interface.IEntity
{
    public interface IUserService
    {
        public Task<BaseResponse<LoginResponse>> Login(LoginViewModel request);
        public Task<BaseResponse<RegisterResponse>> Regiter(RegisterViewModel request);
        public Task<string> ResetPassword(ResetPasswordViewModel request);
        public Task<string> SendResetPassword(SendResetPasswordViewModel request);
    }
}
