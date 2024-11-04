using Application.Base;
using Application.Feature.Auth.Result;
using MediatR;

namespace Application.Feature.Auth.Request.Command
{
    public class LoginViewModel : IRequest<BaseResponse<LoginResponse>>
    {
        public string? email { get; set; }
        public string? password { get; set; }
        public LoginViewModel(string? email, string? password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
