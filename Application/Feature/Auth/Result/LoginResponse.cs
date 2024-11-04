namespace Application.Feature.Auth.Result
{
    public class LoginResponse
    {
        public Guid guid { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }

    }
}
