using MediatR;

namespace Application.Feature.Auth.Request.Command
{
    public class SendResetPasswordViewModel : IRequest<string>
    {
        public string? email { get; set; }
    }
}
