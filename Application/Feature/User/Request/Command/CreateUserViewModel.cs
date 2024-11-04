using MediatR;

namespace Application.Feature.User.Request.Command
{
    public class CreateUserViewModel : IRequest<bool>
    {
        public long PartyRef { get; set; }

        public string? Password { get; set; }
    }
}
