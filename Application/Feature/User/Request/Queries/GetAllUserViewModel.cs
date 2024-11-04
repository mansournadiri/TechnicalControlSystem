using Domain.Entity;

namespace Application.Feature.User.Request.Query
{
    public class GetAllUserViewModel
    {
        public Guid Guid { get; set; }

        public int UserId { get; set; }

        public Party? Party { get; set; }

        public long PartyRef { get; set; }

        public bool IsActive { get; set; }

        public bool IsLocked { get; set; }

        public bool IsDeleted { get; set; }

        public string? BrowserData { get; set; }

        public string? CookieData { get; set; }

        public bool? PasswordIsChanged { get; set; }

        public bool? AppLogin { get; set; }

        public DateTime? AppLoginDateTime { get; set; }

        public DateTime? AppLoginUpdateDateTime { get; set; }

        public string? Ip { get; set; }

        public string? AppMacLogin { get; set; }

        public string? Ipvalid { get; set; }

        public int? Creator { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? Modifier { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? Remove { get; set; }

        public DateTime? RemoveDateTime { get; set; }
    }
}
