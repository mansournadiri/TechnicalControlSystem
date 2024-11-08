namespace Application.Model
{
    public class JWTClaims
    {
        public Guid guid { get; set; }
        public long partyRef { get; set; }
        public string? userName { get; set; }
        public string? role { get; set; }
    }
}
