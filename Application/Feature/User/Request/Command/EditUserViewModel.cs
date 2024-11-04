using MediatR;

namespace Application.Feature.User.Request.Command
{
    public class EditUserViewModel : IRequest<bool>
    {
        public int UserId { get; set; }

        public bool IsActive { get; set; }

        public bool IsLocked { get; set; }

        public bool IsDeleted { get; set; }

        public string? BrowserData { get; set; }

        public string? CookieData { get; set; }

        public string? Password { get; set; }

        public string? PasswordHistory { get; set; }

        public bool? PasswordIsChanged { get; set; }

        public bool? AppLogin { get; set; }

        public string? AppBearerToken { get; set; }

        public string? Ip { get; set; }

        public string? AppMacLogin { get; set; }

        public string? Ipvalid { get; set; }

        public int? Modifier { get; set; }

        public bool? Remove { get; set; }

    }
}
