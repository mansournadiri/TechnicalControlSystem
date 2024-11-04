using Application.Base;
using Application.Feature.Auth.Result;
using MediatR;

namespace Application.Feature.Auth.Request.Command
{
    public class RegisterViewModel : IRequest<BaseResponse<RegisterResponse>>
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? mobileNumber { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
