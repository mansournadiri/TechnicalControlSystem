using MediatR;

namespace Application.Feature.Auth.Request.Command
{
    public class ResetPasswordViewModel : IRequest<string>
    {
        public string? email { get; set; }
        public string? password { get; set; }
        public string? passwordConfirm { get; set; }
        public string? code { get; set; }
    }
}
