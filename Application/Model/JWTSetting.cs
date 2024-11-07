namespace Application.Model
{
    public class JwtSettings
    {
        public JwtSettings()
        {
            Key = "Technic@lC0ntr0l$y$temPl@tf@rmV.1.0.1";
            EncryptionKey = "TechnicalControl";
        }
        public string Key { get; private set; }
        public string EncryptionKey { get; private set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public double DurationInMinutes { get; set; }
    }
}
